package GUI;

import java.awt.BorderLayout;
import java.awt.CardLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JButton;
import java.awt.Font;
import javax.swing.SwingConstants;
import javax.swing.border.LineBorder;
import javax.swing.JLabel;
import java.sql.*;

public class MainMenu extends JFrame {
	
	private HomeUi homeUi = new HomeUi();
	private OrdreUi ordreUi = new OrdreUi();
	private KunderUi kunderUi = new KunderUi();
	private RuteUi ruteUi = new RuteUi();
	private DriverUi driverUi;
	private LastvogneUi lastvogneUi = new LastvogneUi();

	private JPanel contentPane;
	private JLabel lblMenuText;
	private JButton btnHome = new JButton("Home");
	private JButton btnKunder = new JButton("Kunder");
	private JButton btnChauffore = new JButton("Chauff\u00F8re");
	private JButton btnOrdre = new JButton("Ordre");
	private JButton btnRuteplanlagnig = new JButton("Ruteplanl\u00E6gning");
	private JButton btnLastvogne = new JButton("Lastvogne");

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainMenu frame = new MainMenu();
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
	public MainMenu() throws SQLException{
		setTitle("Transport Manage System");
		driverUi = new DriverUi();
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 920, 540);
		
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		CardLayout cl = new CardLayout();
		JPanel wrapPanel = new JPanel(cl);
		wrapPanel.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		wrapPanel.setBounds(160, 60, 754, 451);
		contentPane.add(wrapPanel);
		
		/**/
		/*This are the wrappers*/
		wrapPanel.add(homeUi.getHomePanel(), "Home");
		wrapPanel.add(ruteUi.getRutePanel(), "Rute");
	    wrapPanel.add(ordreUi.getOrdrePanel(), "Ordre");
		wrapPanel.add(kunderUi.getKunderPanel(), "Kunder");
		wrapPanel.add(driverUi.getChaufforePanel(), "Chaufføre");
		wrapPanel.add(lastvogneUi.getLastvognePanel(), "Lastvogne");
		/**/
		
		JPanel MenuPanel = new JPanel();
		MenuPanel.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		MenuPanel.setBackground(new Color(54,73,95));
		MenuPanel.setBounds(0, 0, 914, 511);
		contentPane.add(MenuPanel);
		MenuPanel.setLayout(null);
		
		
		btnKunder.setHorizontalAlignment(SwingConstants.LEFT);
		btnKunder.setFont(new Font("Verdana", Font.BOLD, 13));
		btnKunder.setBounds(0, 400, 160, 40);
		MenuPanel.add(btnKunder);
		btnKunder.setBackground(new Color(103,124,140));
		btnKunder.setOpaque(true);
		btnKunder.setBorderPainted(false);
		btnKunder.setFocusPainted(false);
		btnKunder.setForeground(Color.WHITE);		
		
		btnKunder.addActionListener((e) -> {
				cl.show(wrapPanel, "Kunder");
				lblMenuText.setText("Kunder");
				colorButtons();
				btnKunder.setBackground(new Color(100,100,100));
			});
		
		btnChauffore.addActionListener((e) -> {
				cl.show(wrapPanel, "Chaufføre");
				lblMenuText.setText("Chaufføre");
				colorButtons();
				btnChauffore.setBackground(new Color(100,100,100));
				try {
					driverUi.updatePersonList();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			});
		
		btnChauffore.setHorizontalAlignment(SwingConstants.LEFT);
		btnChauffore.setOpaque(true);
		btnChauffore.setForeground(Color.WHITE);
		btnChauffore.setFont(new Font("Verdana", Font.BOLD, 13));
		btnChauffore.setFocusPainted(false);
		btnChauffore.setBorderPainted(false);
		btnChauffore.setBackground(new Color(103,124,140));
		btnChauffore.setBounds(0, 230, 160, 40);
		MenuPanel.add(btnChauffore);
		
		btnOrdre.addActionListener((e) -> {
				cl.show(wrapPanel, "Ordre");
				lblMenuText.setText("Ordre");
				colorButtons();
				btnOrdre.setBackground(new Color(100,100,100));
				try {
					ordreUi.updateOrderList();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			});
		
		btnOrdre.setHorizontalAlignment(SwingConstants.LEFT);
		btnOrdre.setOpaque(true);
		btnOrdre.setForeground(Color.WHITE);
		btnOrdre.setFont(new Font("Verdana", Font.BOLD, 13));
		btnOrdre.setFocusPainted(false);
		btnOrdre.setBorderPainted(false);
		btnOrdre.setBackground(new Color(103,124,140));
		btnOrdre.setBounds(0, 169, 160, 40);
		MenuPanel.add(btnOrdre);
		
		btnRuteplanlagnig.addActionListener((e) -> {
				cl.show(wrapPanel, "Rute");
				lblMenuText.setText("RutePlanlægning");
				colorButtons();
				btnRuteplanlagnig.setBackground(new Color(100,100,100));
				try {
					ruteUi.init();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			});
		
		btnRuteplanlagnig.setHorizontalAlignment(SwingConstants.LEFT);
		btnRuteplanlagnig.setOpaque(true);
		btnRuteplanlagnig.setForeground(Color.WHITE);
		btnRuteplanlagnig.setFont(new Font("Verdana", Font.BOLD, 13));
		btnRuteplanlagnig.setFocusPainted(false);
		btnRuteplanlagnig.setBorderPainted(false);
		btnRuteplanlagnig.setBackground(new Color(103,124,140));
		btnRuteplanlagnig.setBounds(0, 125, 160, 40);
		MenuPanel.add(btnRuteplanlagnig);
		
		btnLastvogne.addActionListener((e) -> {
				cl.show(wrapPanel, "Lastvogne");
				lblMenuText.setText("Lastvogne");
				colorButtons();
				btnLastvogne.setBackground(new Color(100,100,100));
			});
		
		btnLastvogne.setHorizontalAlignment(SwingConstants.LEFT);
		btnLastvogne.setOpaque(true);
		btnLastvogne.setForeground(Color.WHITE);
		btnLastvogne.setFont(new Font("Verdana", Font.BOLD, 13));
		btnLastvogne.setFocusPainted(false);
		btnLastvogne.setBorderPainted(false);
		btnLastvogne.setBackground(new Color(103,124,140));
		btnLastvogne.setBounds(0, 450, 160, 40);
		MenuPanel.add(btnLastvogne);
		
		lblMenuText = new JLabel("Main Menu");
		lblMenuText.setForeground(Color.WHITE);
		lblMenuText.setFont(new Font("Verdana", Font.BOLD, 25));
		lblMenuText.setBounds(200, 18, 437, 31);
		MenuPanel.add(lblMenuText);
		
		btnHome.addActionListener((e) -> {
				cl.show(wrapPanel, "Home");
				lblMenuText.setText("Home");
				colorButtons();
				btnHome.setBackground(new Color(100,100,100));
			});
		
		btnHome.setBounds(0, 62, 160, 40);
		btnHome.setHorizontalAlignment(SwingConstants.LEFT);
		btnHome.setOpaque(true);
		btnHome.setForeground(Color.WHITE);
		btnHome.setFont(new Font("Verdana", Font.BOLD, 13));
		btnHome.setFocusPainted(false);
		btnHome.setBorderPainted(false);
		btnHome.setBackground(new Color(103,124,140));
		MenuPanel.add(btnHome);
	}
	
	public void colorButtons(){
		btnHome.setBackground(new Color(103,124,140));
		btnLastvogne.setBackground(new Color(103,124,140));
		btnRuteplanlagnig.setBackground(new Color(103,124,140));
		btnOrdre.setBackground(new Color(103,124,140));
		btnChauffore.setBackground(new Color(103,124,140));
		btnKunder.setBackground(new Color(103,124,140));
	}
}
