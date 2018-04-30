package GUI;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.LineBorder;

import ModelLayer.Route;
import ControlLayer.RouteController;

import javax.swing.JLabel;
import java.awt.Font;
import javax.swing.JTextField;
import javax.swing.JTextArea;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class ViewRute extends JFrame {
	//private Route r;
	private RouteController rCtr;
	
	private JPanel contentPane;
	private JTextField txtStartAddress;
	private JTextField txtEndAddress;
	private JTextField txtCustomer;
	private JTextField txtDriver;
	private JTextField txtWeight;
	private JTextArea txtRoute;
	private JTextArea txtProduct;
	private JTextField txtHeight;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ViewRute frame = new ViewRute();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public ViewRute() {
		rCtr = new RouteController();
		
		setResizable(false);
		setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		setBounds(100, 100, 515, 370);
		contentPane = new JPanel();
		contentPane.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JPanel panel = new JPanel();
		panel.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		panel.setBackground(new Color(54,73,95));
		panel.setBounds(0, 0, 509, 40);
		contentPane.add(panel);
		
		JLabel lblCharlieJensenTransport = new JLabel("Den oprettede rute");
		lblCharlieJensenTransport.setForeground(Color.WHITE);
		lblCharlieJensenTransport.setFont(new Font("Tahoma", Font.BOLD, 15));
		panel.add(lblCharlieJensenTransport);
		
		JLabel lblStart = new JLabel("Start Sted");
		lblStart.setBounds(254, 51, 84, 14);
		contentPane.add(lblStart);
		
		txtStartAddress = new JTextField();
		txtStartAddress.setEditable(false);
		txtStartAddress.setBounds(252, 65, 86, 20);
		contentPane.add(txtStartAddress);
		txtStartAddress.setColumns(10);
		
		JLabel lblSlut = new JLabel("Slut Sted");
		lblSlut.setBounds(349, 51, 85, 14);
		contentPane.add(lblSlut);
		
		txtEndAddress = new JTextField();
		txtEndAddress.setEditable(false);
		txtEndAddress.setBounds(348, 65, 86, 20);
		contentPane.add(txtEndAddress);
		txtEndAddress.setColumns(10);
		
		JLabel lblPlanlagteRute = new JLabel("Planlagte Rute");
		lblPlanlagteRute.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblPlanlagteRute.setBounds(10, 62, 113, 14);
		contentPane.add(lblPlanlagteRute);
		
		JLabel lblKunde = new JLabel("Kunde");
		lblKunde.setBounds(254, 96, 46, 14);
		contentPane.add(lblKunde);
		
		txtCustomer = new JTextField();
		txtCustomer.setEditable(false);
		txtCustomer.setBounds(252, 113, 86, 20);
		contentPane.add(txtCustomer);
		txtCustomer.setColumns(10);
		
		JLabel lblChauffr = new JLabel("Chauff\u00F8r");
		lblChauffr.setBounds(349, 96, 85, 14);
		contentPane.add(lblChauffr);
		
		txtDriver = new JTextField();
		txtDriver.setEditable(false);
		txtDriver.setBounds(349, 113, 86, 20);
		contentPane.add(txtDriver);
		txtDriver.setColumns(10);
		
		JLabel lblVgt = new JLabel("V\u00E6gt");
		lblVgt.setBounds(254, 144, 46, 14);
		contentPane.add(lblVgt);
		
		txtWeight = new JTextField();
		txtWeight.setEditable(false);
		txtWeight.setBounds(252, 160, 86, 20);
		contentPane.add(txtWeight);
		txtWeight.setColumns(10);
		
		JLabel lblProduct = new JLabel("Produkt");
		lblProduct.setBounds(254, 191, 46, 14);
		contentPane.add(lblProduct);
		
		txtProduct = new JTextArea();
		txtProduct.setEditable(false);
		txtProduct.setBounds(254, 204, 179, 76);
		txtProduct.setBorder(new LineBorder(new Color(0, 0, 0)));
		contentPane.add(txtProduct);
		
		JButton btnLuk = new JButton("Luk");
		btnLuk.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				cancel();
			}
		});
		btnLuk.setBounds(400, 297, 89, 23);
		btnLuk.setBackground(new Color(174,79,79));
		btnLuk.setOpaque(true);
		btnLuk.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnLuk.setFocusPainted(false);
		btnLuk.setForeground(Color.WHITE);
		contentPane.add(btnLuk);
		
		txtRoute = new JTextArea();
		txtRoute.setEditable(false);
		txtRoute.setFont(new Font("Verdana", Font.BOLD, 15));
		txtRoute.setBounds(20, 87, 190, 230);
		txtRoute.setBorder(new LineBorder(new Color(0, 0, 0)));
		contentPane.add(txtRoute);
		
		JButton btnMap = new JButton("Se Kort");
		btnMap.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ViewMap vm = new ViewMap();
				vm.setVisible(true);
			}
		});
		btnMap.setOpaque(true);
		btnMap.setForeground(Color.WHITE);
		btnMap.setFocusPainted(false);
		btnMap.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnMap.setBackground(new Color(94, 109, 126));
		btnMap.setBounds(121, 51, 89, 23);
		contentPane.add(btnMap);
		
		JLabel lblHjde = new JLabel("H\u00F8jde");
		lblHjde.setBounds(349, 144, 85, 14);
		contentPane.add(lblHjde);
		
		txtHeight = new JTextField();
		txtHeight.setEditable(false);
		txtHeight.setBounds(349, 160, 86, 20);
		contentPane.add(txtHeight);
		txtHeight.setColumns(10);
	}
	
	private void cancel(){
		this.setVisible(false);
		this.dispose();	
	}
	
	public void setRoute(Route r) {
		//this.r = r;		
		txtStartAddress.setText(r.getOrder().getStartAddress());
		txtEndAddress.setText(r.getOrder().getEndAddress());
		txtCustomer.setText("");
		txtDriver.setText(r.getDriver().getFirstName() + " " + r.getDriver().getLastName());
		txtWeight.setText(Double.toString(r.getOrder().getWeight()));
		txtRoute.setText(rCtr.printRoute(r.getOrder().getStartAddress(), r.getOrder().getEndAddress(), r.getOrder().getWeight(), r.getOrder().getHeight())
				+ "\n " + r.getLength() + "km" + "\n " + String.format("%.2f",r.getTime()) + "t.");
		txtProduct.setText(r.getOrder().getProduct());
		txtHeight.setText(Double.toString(r.getOrder().getHeight()));
		
	}
}
