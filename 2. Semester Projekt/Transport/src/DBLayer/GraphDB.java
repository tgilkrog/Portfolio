package DBLayer;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import ModelLayer.AStarPath.Node;
import ModelLayer.AStarPath.Edge;

public class GraphDB {
	
	private static final String findAllNodesQ =
			"select * FROM nodes";
	
	private static final String findNodesByIdQ =
			findAllNodesQ + " where cityname = ?";
	
	private static final String findAllEdgesQ =
			"select * FROM edges";
	
	private static final String findEdgesByIdQ =
			 "select * from edges, nodes where edges.city = nodes.cityname AND nodes.cityname = ?";
	
	
	private PreparedStatement findAllNodes, findNodesById, findAllEdges, findEdgesById;
	
	public GraphDB() {
		try{
			findAllNodes = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllNodesQ);
			findNodesById = DBConnection.getInstance().getConnection()
					.prepareStatement(findNodesByIdQ);
			findAllEdges = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllEdgesQ);
			findEdgesById = DBConnection.getInstance().getConnection()
					.prepareStatement(findEdgesByIdQ);

		}
		catch (SQLException e) {
		}
	}
	
	public List<Node> findAll() throws SQLException  {
		ResultSet rs;

			rs = findAllNodes.executeQuery();
			List<Node> res = buildObjects(rs);
			return res;
	} 
	
	public Node findNodeByName(String city) throws SQLException{
		findNodesById.setString(1, city);
		ResultSet rs = findNodesById.executeQuery();
		Node n = null;
		if(rs.next()) {
			n = buildObject(rs);
		}
		return n;
	}
	
	public List<Edge> findAllEdges() throws SQLException  {
		ResultSet rs;

			rs = findAllEdges.executeQuery();
			List<Edge> res = buildEdgeObjects(rs);
			return res;
	} 
	
	public Edge findEdgeBy(String city) throws SQLException{
		findEdgesById.setString(1, city);
		ResultSet rs = findEdgesById.executeQuery();
		Edge e = null;
		if(rs.next()) {
			e = buildEdgeObject(rs);
		}
		return e;
	}

	private Node buildObject(ResultSet rs) throws SQLException {
		Node n = null;
		n = new Node();
		n.setValue(rs.getString("cityname"));
		n.setHeuristic(rs.getDouble("heuristic"));
		return n;
	}
	
	private ArrayList<Node> buildObjects(ResultSet rs) throws SQLException {
		ArrayList<Node> res = new ArrayList<>();
		while(rs.next()) {
			Node n = buildObject(rs);
			res.add(n);
		}
		return res;
	}
	
	private Edge buildEdgeObject(ResultSet rs) throws SQLException {
		Edge e = null;
		e = new Edge();
		e.setTarget(findNodeByName(rs.getString("nodeTarget")));
		e.setCost(rs.getDouble("elength"));
		e.setAkseltryk(rs.getDouble("akseltryk"));
		return e;
	}
	
	private ArrayList<Edge> buildEdgeObjects(ResultSet rs) throws SQLException {
		ArrayList<Edge> res = new ArrayList<>();
		while(rs.next()) {
			Edge e = buildEdgeObject(rs);
			res.add(e);
		}
		return res;
	}
}
