package GUI;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.DefaultListModel;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.sql.SQLException;
import java.util.List;
import java.awt.event.ActionEvent;
import javax.swing.border.LineBorder;
import java.awt.Font;

import ModelLayer.Driver;
import ModelLayer.Order;
import ModelLayer.Route;
import GUI.Renderes.RouteListRenderer;
import GUI.Renderes.OrderListRenderer;
import GUI.Renderes.DriverListRenderer;
import ControlLayer.RouteController;
import DBLayer.DriverDB;
import GUI.ViewRute;

public class RuteUi extends JFrame {

	private JPanel contentPane;
	private RouteController rouCtr;
	
	private JList<Driver> drivers;
	private JList<Order> orders;
	private JList<Route> routes;
	private DriverDB dDB;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					RuteUi frame = new RuteUi();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 * @throws SQLException 
	 */
	public RuteUi() throws SQLException {
		rouCtr = new RouteController();
		dDB = new DriverDB();
		
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 744, 473);
		contentPane = new JPanel();
		contentPane.setBackground(new Color(227, 225, 224));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JPanel rutePanel = new JPanel();
		rutePanel.setBackground(new Color(204,204,204));
		rutePanel.setBorder(new LineBorder(new Color(0, 0, 0)));
		rutePanel.setBounds(10, 11, 730, 247);
		contentPane.add(rutePanel);
		
		JLabel lblOpretNyrute = new JLabel("Opret Ny Rute");
		lblOpretNyrute.setBounds(7, 6, 121, 22);
		lblOpretNyrute.setFont(new Font("Verdana", Font.BOLD, 15));
		rutePanel.add(lblOpretNyrute);
		
		/**
		 * @DriversList
		 */		
		JLabel lblChauffore = new JLabel("V\u00E6lg En Ledig Chauff\u00F8re");
		lblChauffore.setFont(new Font("Verdana", Font.BOLD, 12));
		lblChauffore.setBounds(10, 39, 250, 22);
		rutePanel.add(lblChauffore);
		
		DefaultListModel<Driver> model = new DefaultListModel<>();
		rutePanel.setLayout(null);
		drivers = new JList<>( model );
		drivers.setBounds(10, 64, 250, 172);
		drivers.setBorder(new LineBorder(new Color(0, 0, 0)));
		rutePanel.add(drivers);
		
		/**
		 * @OrdersList
		 */		
		JLabel lblOrdre = new JLabel("V\u00E6lg En Ordrer");
		lblOrdre.setFont(new Font("Verdana", Font.BOLD, 12));
		lblOrdre.setBounds(316, 39, 124, 22);
		rutePanel.add(lblOrdre);
		
		DefaultListModel<Order> model2 = new DefaultListModel<>();
		orders = new JList<>( model2 );
		orders.setBounds(316, 64, 250, 172);
		orders.setBorder(new LineBorder(new Color(0, 0, 0)));
		rutePanel.add(orders);
		
		
		JButton btnOpret = new JButton("Opret En Rute");
		btnOpret.setBounds(596, 193, 124, 43);
		rutePanel.add(btnOpret);
		
		btnOpret.addActionListener((e) -> {
				try {
					createRoute();
					init();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		});
		btnOpret.setBackground(new Color(94,109,126));
		btnOpret.setOpaque(true);
		btnOpret.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnOpret.setFocusPainted(false);
		btnOpret.setForeground(Color.WHITE);
		
		/**
		 * Her læses de Oprettede Ruter
		 * @OprettedeRuter
		 */
		JPanel oprettedeRuterPanel = new JPanel();
		oprettedeRuterPanel.setBorder(new LineBorder(new Color(0, 0, 0)));
		oprettedeRuterPanel.setBackground(new Color(204,204,204));
		oprettedeRuterPanel.setBounds(10, 264, 730, 169);
		contentPane.add(oprettedeRuterPanel);
		oprettedeRuterPanel.setLayout(null);
		
		JLabel lblOprettede = new JLabel("Oprettede Ruter");
		lblOprettede.setBounds(10, 11, 154, 20);
		lblOprettede.setFont(new Font("Verdana", Font.BOLD, 15));
		oprettedeRuterPanel.add(lblOprettede);
		
		DefaultListModel<Route> model3 = new DefaultListModel<>();
		routes = new JList<>( model3 );
		routes.setBorder(new LineBorder(new Color(0, 0, 0)));
		routes.setBounds(10, 40, 540, 118);
		oprettedeRuterPanel.add(routes);
		
		JButton btnView = new JButton("Se Oprettet Rute");
		btnView.addActionListener((e) -> {
				try {
					showRoute();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		});
		btnView.setOpaque(true);
		btnView.setForeground(Color.WHITE);
		btnView.setFocusPainted(false);
		btnView.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnView.setBackground(new Color(94, 109, 126));
		btnView.setBounds(580, 40, 140, 34);
		oprettedeRuterPanel.add(btnView);
		
		JButton btnSlet = new JButton("Slet Oprettet Rute");
		btnSlet.addActionListener((e) -> {
					try {
						deleteRoute();
					} catch (SQLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
		});
		btnSlet.setOpaque(true);
		btnSlet.setForeground(Color.WHITE);
		btnSlet.setFocusPainted(false);
		btnSlet.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSlet.setBackground(new Color(174,79,79));
		btnSlet.setBounds(580, 124, 140, 34);
		oprettedeRuterPanel.add(btnSlet);
		
		init();
	}
	
	public void init() throws SQLException{
		routes.setCellRenderer(new RouteListRenderer());
		drivers.setCellRenderer(new DriverListRenderer());
		orders.setCellRenderer(new OrderListRenderer());
		updateRouteList();
		updateOrderList();
		updateDriverList();
	}
	
	public void createRoute() throws SQLException{
		if (drivers.getSelectedValue() == null || orders.getSelectedValue() == null){
			JOptionPane.showMessageDialog(null, "Der skal vælges både Chauffør og Ordre!", "Fejl!", JOptionPane.ERROR_MESSAGE);
		}
		else if(rouCtr.findDriverById(drivers.getSelectedValue().getId()).getAvailable() == false){
			JOptionPane.showMessageDialog(null, "Den chauffør du har valgt er allerede på en rute");
			init();
		}
		else if(drivers.getSelectedValue() != null && orders.getSelectedValue() != null){
			double length = rouCtr.getLength(orders.getSelectedValue().getStartAddress(), orders.getSelectedValue().getEndAddress(), orders.getSelectedValue().getWeight(), orders.getSelectedValue().getHeight());
			double time = length/60;
			rouCtr.createRoute(drivers.getSelectedValue(), orders.getSelectedValue(), time, length);
			rouCtr.updateDriverAvailable(false, drivers.getSelectedValue().getId());
			JOptionPane.showMessageDialog(null, "En Rute blev Oprettet!");
		}
	}
	
	public void deleteRoute() throws SQLException{
		if(routes.getSelectedValue() != null){
			rouCtr.deleteRoute(routes.getSelectedValue().getId());
			rouCtr.updateDriverAvailable(true, routes.getSelectedValue().getDriver().getId());
			JOptionPane.showMessageDialog(null, "En Rute blev slettet!");
			init();
		}
		else{
			JOptionPane.showMessageDialog(null, "Der blev ikke valgt en Rute!", "Fejl!", JOptionPane.ERROR_MESSAGE);
		}
	}
	
	private void updateOrderList() throws SQLException{
		List<Order> ppl = rouCtr.getAllOrders();
		DefaultListModel<Order> dlm = new DefaultListModel<>();
		for(int i = 0 ; i < ppl.size(); i++) {
			dlm.addElement(ppl.get(i));
		}
		this.orders.setModel(dlm);
	}
	
	private void updateDriverList() throws SQLException{
		List<Driver> ppl = rouCtr.gettAllAvailableDrivers(true);
		DefaultListModel<Driver> dlm = new DefaultListModel<>();
		for(int i = 0 ; i < ppl.size(); i++) {
			dlm.addElement(ppl.get(i));
		}
		this.drivers.setModel(dlm);
	}
	
	public void updateRouteList() throws SQLException{
		List<Route> ppl = rouCtr.getAllRoutes();
		DefaultListModel<Route> dlm = new DefaultListModel<>();
		for(int i = 0 ; i < ppl.size(); i++) {
			dlm.addElement(ppl.get(i));
		}
		this.routes.setModel(dlm);
	}
	
	private void showRoute() throws SQLException {
		Route r = routes.getSelectedValue();
//		double length = rouCtr.getLength(r.getOrder().getStartAddress(), r.getOrder().getEndAddress(), r.getOrder().getWeight(), r.getOrder().getHeight());
//		double time = length/60;
//		r.setLength(length);
//		r.setTime(time);
		
		if(r != null) {
			ViewRute viewRute = new ViewRute();
			viewRute.setRoute(r);
			viewRute.setVisible(true);
			//updateRouteList();
		}
		else{
			JOptionPane.showMessageDialog(null, "Der skal vælges en rute!", "Fejl!", JOptionPane.ERROR_MESSAGE);
		}
	}
	
	public JPanel getRutePanel()
	{
		return contentPane;
	}
}
