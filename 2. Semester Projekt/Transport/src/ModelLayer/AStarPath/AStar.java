package ModelLayer.AStarPath;

import java.util.PriorityQueue;
import java.util.HashSet;
import java.util.Set;
import java.util.List;
import java.util.Comparator;
import java.util.ArrayList;
import java.util.Collections;

public class AStar{

	public static List<Node> printPath(Node target){
		List<Node> path = new ArrayList<Node>();
        
        for(Node node = target; node!=null; node = node.getParent()){
            path.add(node);
        	}

        Collections.reverse(path);
        
        return path;
	}

	public static void AstarSearch(Node source, Node goal, double weight, double height){

		//laver et hashset af noder kaldet explored
		Set<Node> explored = new HashSet<Node>();

        //The elements of the priority queue are ordered according to their natural ordering,
        //or by a Comparator provided at queue construction time, depending on which constructor is used.
		PriorityQueue<Node> queue = new PriorityQueue<Node>(20, new Comparator<Node>(){
            
        	//override compare method by f_score size
        	public int compare(Node i, Node j){
        		if(i.getF_scores() > j.getF_scores()){
        			return 1;
                }

                else if (i.getF_scores() < j.getF_scores()){
                	return -1;
                }

                else{
                	return 0;
                }
            }
        });

        //cost from start
		//source is the Start node
        source.setG_scores(0); 
        queue.add(source);
        boolean found = false;

        //if queue is not empty, and found is false
        while((!queue.isEmpty())&&(!found)){

        	//the node  having the lowest f_score value, in relation to the priorityqueue
            Node current = queue.poll();
            explored.add(current);

            //goal found
            if(current.getValue().equals(goal.getValue())){
            	found = true;
            }

            //check every child of current node
            for(Edge e : current.edges){
            	//checks if the weight of the truck/order is lower than the akseltryk 
            	//if it is it will skip it and go to the next edge
            	if(weight > e.getAkseltryk() || e.getBridgeHeight() < height){
            		continue;
            	}
            	
            	else{
            		Node child = e.getTarget();
            		//here is where it checks the length of the edge between the two nodes
            		double cost = e.getCost();
            		double temp_g_scores = current.getG_scores() + cost;
            		//h_score is the heuristic score
            		double temp_f_scores = temp_g_scores + child.getH_scores();

            		/*if child node has been evaluated and 
                	the newer f_score is higher, skip*/                
            		if((explored.contains(child)) && (temp_f_scores >= child.getF_scores())){
            			continue;
            		}

            		/*else if child node is not in queue or 
                	newer f_score is lower*/   
            		else if((!queue.contains(child)) || (temp_f_scores < child.getF_scores())){

            			child.setParent(current);
            			child.setG_scores(temp_g_scores);
            			child.setF_scores(temp_f_scores);

            			if(queue.contains(child)){
            				queue.remove(child);
            			}
            			queue.add(child);
            		}
            	}
            }
        }
	}
}