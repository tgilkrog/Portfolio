package ModelLayer.AStarPath;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class Node {
	
    private String value;
    private double g_scores;
    private double h_scores;
    private double f_scores = 0;
    private Node parent;
    public List<Edge> edges;

	public Node(String value, double h_scores){
		edges = new LinkedList<Edge>();
        this.value = value;
        this.h_scores = h_scores;
	}
	public Node(){}

	public List<Edge> getEdges() {
		return edges;
	}
	public void setEdges(List<Edge> edges) {
		this.edges = edges;
	}
	public String toString(){
        return value;
	}
    
    public double getG_scores() {
		return g_scores;
	}

	public void setG_scores(double g_scores) {
		this.g_scores = g_scores;
	}

	public double getF_scores() {
		return f_scores;
	}

	public void setF_scores(double f_scores) {
		this.f_scores = f_scores;
	}

//	public Edge[] getAdjacencies() {
//		return adjacencies;
//	}
//
//	public void setAdjacencies(Edge[] adjacencies) {
//		this.adjacencies = adjacencies;
//	}

	public Node getParent() {
		return parent;
	}

	public void setParent(Node parent) {
		this.parent = parent;
	}

	public String getValue() {
		return value;
	}
	
	public void setValue(String value){
		this.value = value;
	}
	public void setHeuristic(double h_scores){
		this.h_scores = h_scores;
	}

	public double getH_scores() {
		return h_scores;
	}
}
