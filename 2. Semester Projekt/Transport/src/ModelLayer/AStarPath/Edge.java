package ModelLayer.AStarPath;
public class Edge {
	
    private double cost;
    private Node target;
    private double akseltryk;
    private double bridgeHeight;
    

    public Edge(Node target, double cost, double akseltryk, double bridgeHeight){
            this.target = target;
            this.cost = cost;
            this.akseltryk = akseltryk;
            this.bridgeHeight = bridgeHeight;
    }
    
    public Edge(){}
    
    

	public double getBridgeHeight() {
		return bridgeHeight;
	}

	public void setBridgeHeight(double bridgeHeight) {
		this.bridgeHeight = bridgeHeight;
	}

	public double getCost() {
		return cost;
	}

	public void setCost(double cost) {
		this.cost = cost;
	}

	public Node getTarget() {
		return target;
	}

	public void setTarget(Node target) {
		this.target = target;
	}

	public double getAkseltryk() {
		return akseltryk;
	}

	public void setAkseltryk(double akseltryk) {
		this.akseltryk = akseltryk;
	}
    
    
    
    
}