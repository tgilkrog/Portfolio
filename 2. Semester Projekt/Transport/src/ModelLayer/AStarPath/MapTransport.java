package ModelLayer.AStarPath;

import java.sql.SQLException;
import java.util.LinkedList;
import java.util.List;
import DBLayer.GraphDB;

public class MapTransport {

	private List<Node> nodes = new LinkedList<Node>();        
	
	public MapTransport(){
		//initialize the graph heuristic taken from Sørup
		//h_scores is the straight-line distance from Sørup to the other cities.
		Node sorup = new Node("Sørup",0);
        Node aalborg = new Node("Aalborg",25);
        Node aars = new Node("Aars",25);
        Node hirtshals = new Node("Hirtshals",200);
        Node viborg = new Node("Viborg", 60);
        Node herning = new Node("Herning", 100);
        Node holstebro = new Node("Holstebro", 150);
        Node frederikshavn = new Node("Frederikshavn", 80);         
            
        //initialize the edges with a length and "akseltryk", they also have a bridge height 
        // hose that does not have a bridge have a height set to 10, and adds them the nodes edges"
        sorup.edges.add(new Edge(aalborg, 25, 5, 10));
        sorup.edges.add(new Edge(aars, 25, 5, 10));
        sorup.edges.add(new Edge(viborg, 60, 60, 10));
        
        aalborg.edges.add(new Edge(sorup, 25, 5, 10));
        aalborg.edges.add(new Edge(aars, 45, 60, 10));
        aalborg.edges.add(new Edge(hirtshals, 67, 60, 10));
        aalborg.edges.add(new Edge(frederikshavn, 64, 60, 10));
        
        aars.edges.add(new Edge(sorup, 25, 5, 10));
        aars.edges.add(new Edge(aalborg, 45, 60, 10));
        aars.edges.add(new Edge(holstebro, 50, 60, 10));
        aars.edges.add(new Edge(viborg, 44, 50, 4.00));
        
        hirtshals.edges.add(new Edge(aalborg, 67, 60, 10));
        hirtshals.edges.add(new Edge(aalborg, 67, 60, 10));
        
        viborg.edges.add(new Edge(sorup, 60, 60, 10));
        viborg.edges.add(new Edge(herning, 48, 60, 10));
        viborg.edges.add(new Edge(aars, 44, 50, 4.00));
        viborg.edges.add(new Edge(holstebro, 50, 10, 4.50));
        
        herning.edges.add(new Edge(viborg, 48, 60, 10));
        herning.edges.add(new Edge(holstebro, 35, 60, 10));
        
        holstebro.edges.add(new Edge(herning, 35, 60, 10));
        holstebro.edges.add(new Edge(aars, 50, 60, 10));
        holstebro.edges.add(new Edge(viborg, 50, 10, 4.50));
        
        frederikshavn.edges.add(new Edge(aalborg, 64, 60, 10));
        frederikshavn.edges.add(new Edge(hirtshals, 45, 60, 10));
            
        //Add cities to nodes list which is a linkedlist
        nodes.add(sorup);
        nodes.add(aalborg);
        nodes.add(aars);
        nodes.add(hirtshals);
        nodes.add(viborg);
        nodes.add(herning);
        nodes.add(holstebro);
        nodes.add(frederikshavn);
	}		
	
	/**
	 * Method for searching the different nodes in the list nodes;
	 */
	public Node searchNodes(String nodeName){
		Node node1 = null;
		for(Node n : nodes){
			if(n.getValue().equals(nodeName)){
			node1 = n;
			}
		}
		return node1;
	}
	
	/**
	 * Method for planning the route, it takes two nodes and a weight, it uses the method AstarSearch
	 */
	public String routePlan(String start, String end, double weight, double height){
		String route = "";
		Node nStart = searchNodes(start);
		Node nEnd = searchNodes(end);

		AStar.AstarSearch(nStart, nEnd, weight, height);

        List<Node> path = AStar.printPath(nEnd);
        
        for(Node n : path){
        	route = route + " " + n.getValue() + "\n";
        }
        
        return route;
	}
	
	/**
	 * MEthod for getting the length of a route.
	 */
	public double getLength(String start, String end, double weight, double height){		
		Node nStart = searchNodes(start);
		Node nEnd = searchNodes(end);
		
		AStar.AstarSearch(nStart, nEnd, weight, height);

		List<Node> path = AStar.printPath(nEnd);
		
		return nEnd.getG_scores();
	}
}
