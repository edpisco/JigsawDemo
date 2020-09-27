<template>
  <div>
    <div class="graph-component-container" ref="GraphComponentElement"></div>
  </div>
</template>

<script lang="ts">

import {
  GraphComponent,
  GraphViewerInputMode,
  License,
  ShapeNodeStyle,
  Size,
  TreeLayout
} from 'yfiles'
import axios from 'axios';
import license from "../license";
import populateTreeGraph from "../graphGenerator";
import constants from '../constants';
import {Vue} from "vue-property-decorator";

License.value = license;

let graphComponent: GraphComponent;

const Demo = Vue.extend({
  name: 'Demo',
  async mounted() {
    const graphRef = this.$refs.GraphComponentElement as HTMLDivElement;
    graphComponent = new GraphComponent(graphRef)
    graphComponent.inputMode = new GraphViewerInputMode()
    graphComponent.graph.nodeDefaults.size = new Size(260, 60)

    this.initializeDefaultStyles()
    await this.createGraph()
  },
  methods: {
    initializeDefaultStyles() {
      graphComponent.graph.nodeDefaults.style = new ShapeNodeStyle({
        fill: 'orange',
        stroke: 'black',
        shape: 'rectangle'
      })
    },

    async createGraph() {
      let graph = graphComponent.graph;
      graph.clear();

      const response = await axios.get(constants.API_URL);
      if (response.status !== 200) {
        console.log(response.statusText);
        return;
      }

      const data = response.data;

      graph = populateTreeGraph(data, graph);
      graph.applyLayout(new TreeLayout())
      graphComponent.fitGraphBounds();
      const inputMode =  new GraphViewerInputMode();
      inputMode.addItemDoubleClickedListener((sender, args)  => {
        const node = args.item
        if (node.tag !== null) {
          const newNode = {
            parentId: node.tag.id,
            name: `Child of ${node.tag.name}`
          }
          axios.post(constants.API_URL, newNode).then(response => {
            if (response.status !== 200) {
              console.log('Save failed');
              return;
            }
            this.createGraph();
          });
        }
      });

      graphComponent.inputMode = inputMode;
    }
  }
})

export default Demo

</script>

<style scoped>
@import '~yfiles/yfiles.css';

.graph-component-container {
  position: absolute;
  top: 100px;
  left: 0;
  right: 0;
  bottom: 0;
}
</style>
