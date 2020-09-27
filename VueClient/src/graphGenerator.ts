import {IGraph, TreeBuilder} from "yfiles";
import {ITreeItem} from "@/ITreeItem";

export const populateTreeGraph = (data: ITreeItem, graph: IGraph): IGraph => {
    const treeBuilder = new TreeBuilder(graph);
    const rootNodesSource = treeBuilder.createRootNodesSource<ITreeItem>([data]);
    rootNodesSource.nodeCreator.createLabelBinding(x => x.name);
    const childNodesSource = rootNodesSource.createChildNodesSource(n => n.children)
    childNodesSource.addChildNodesSource(n => n.children, rootNodesSource)
    childNodesSource.nodeCreator.createLabelBinding(x => x.name);
    return treeBuilder.buildGraph();
}

export default populateTreeGraph