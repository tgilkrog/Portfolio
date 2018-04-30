package GUI;
import ControlLayer.*;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.sql.SQLException;
import java.util.List;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.border.LineBorder;

import ModelLayer.Driver;
import GUI.Renderes.DriverListRenderer;

import javax.swing.JLabel;

public class DriverUi extends JFrame {
	
	DriverController dCtr;

	private JPanel contentPane;
	private JList<Driver> lstPerson;
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					DriverUi frame = new DriverUi();
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
	public DriverUi() throws SQLException{

		dCtr = new DriverController();
		
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 744, 450);
		contentPane = new JPanel();
		contentPane.setBackground(new Color(227, 225, 224));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JPanel chaufforePanel = new JPanel();
		chaufforePanel.setBackground(new Color(204,204,204));
		chaufforePanel.setBorder(new LineBorder(new Color(0, 0, 0)));
		chaufforePanel.setBounds(10, 11, 730, 277);
		contentPane.add(chaufforePanel);
		chaufforePanel.setLayout(null);
		
		JButton btnEdit = new JButton("\u00C6ndre Chauff\u00F8r");
		btnEdit.setBounds(590, 92, 130, 45);
		chaufforePanel.add(btnEdit);
		btnEdit.addActionListener((e) -> {
			try {
				showDriver();
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
//				ViewChauffore vc = new ViewChauffore();
//				vc.setVisible(true);
			});
		
		btnEdit.setBackground(new Color(94,109,126));
		btnEdit.setOpaque(true);
		//btnEdit.setBorderPainted(true);
		btnEdit.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnEdit.setFocusPainted(false);
		btnEdit.setForeground(Color.WHITE);
		
		JButton btnSlet = new JButton("Slet Chauff\u00F8r");
		btnSlet.setBounds(590, 221, 130, 45);
		chaufforePanel.add(btnSlet);
		btnSlet.addActionListener((e) -> {
				try {
					deleteDriver();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		});
		btnSlet.setBackground(new Color(174,79,79));
		btnSlet.setOpaque(true);
		//btnSlet.setBorderPainted(false);
		btnSlet.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSlet.setFocusPainted(false);
		btnSlet.setForeground(Color.WHITE);
		
		JLabel lblChauffore = new JLabel("Chauff\u00F8re");
		lblChauffore.setFont(new Font("Verdana", Font.BOLD, 15));
		lblChauffore.setBounds(10, 11, 84, 20);
		chaufforePanel.add(lblChauffore);
		
		JScrollPane scrollPane = new JScrollPane();
		contentPane.add(scrollPane, BorderLayout.CENTER);
		
		/**
		 * List med chaufførene
		 * @JListPerson
		 */
		lstPerson = new JList<>();
		lstPerson.setCellRenderer(new DriverListRenderer());
		scrollPane.setViewportView(lstPerson);
		lstPerson.setFont(new Font("Verdana", Font.BOLD, 12));
		lstPerson.setBorder(new LineBorder(new Color(0, 0, 0)));
		lstPerson.setBounds(10, 36, 550, 230);
		chaufforePanel.add(lstPerson);	
		
		/**
		 * @btnOpret
		 */
		JButton btnOpret = new JButton("Opret Chauff\u00F8r");
		btnOpret.setOpaque(true);
		btnOpret.setForeground(Color.WHITE);
		btnOpret.setFocusPainted(false);
		//btnOpret.setBorderPainted(false);
		btnOpret.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnOpret.setBackground(new Color(94, 109, 126));
		btnOpret.setBounds(590, 36, 130, 45);
		chaufforePanel.add(btnOpret);
		btnOpret.addActionListener((e) -> {
				ViewDriver vd = new ViewDriver();
				vd.changeTitle(btnOpret.getText());
				vd.buttonView(2);
				vd.setVisible(true);	
			});
		
		JPanel panelAflosere = new JPanel();
		panelAflosere.setBorder(new LineBorder(new Color(0, 0, 0)));
		panelAflosere.setBackground(new Color(204, 204, 204));
		panelAflosere.setBounds(10, 299, 730, 140);
		contentPane.add(panelAflosere);
		panelAflosere.setLayout(null);
		
		/**
		 * @ListAflosere
		 */
		DefaultListModel<String> model2 = new DefaultListModel<>();
		JList<String> list2 = new JList<>( model2 );
		list2.setFont(new Font("Verdana", Font.BOLD, 12));
		list2.setBorder(new LineBorder(new Color(0, 0, 0)));
		list2.setBounds(10, 36, 570, 93);
		panelAflosere.add(list2);
		
		JLabel lblAflosere = new JLabel("Afl\u00F8sere");
		lblAflosere.setFont(new Font("Verdana", Font.BOLD, 15));
		lblAflosere.setBounds(10, 11, 84, 20);
		panelAflosere.add(lblAflosere);
		
		JButton btnndreAflser = new JButton("\u00C6ndre Afl\u00F8ser");
			btnndreAflser.addActionListener((e) -> {
			ViewDriver vd = new ViewDriver();
			vd.changeTitle(btnndreAflser.getText());
			vd.setVisible(true);
			});
			
		btnndreAflser.setOpaque(true);
		btnndreAflser.setForeground(Color.WHITE);
		btnndreAflser.setFocusPainted(false);
		//btnndreAflser.setBorderPainted(false);
		btnndreAflser.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnndreAflser.setBackground(new Color(94, 109, 126));
		btnndreAflser.setBounds(600, 68, 120, 25);
		panelAflosere.add(btnndreAflser);
		
		JButton btnSletAflser = new JButton("Slet Afl\u00F8ser");
		btnSletAflser.setOpaque(true);
		btnSletAflser.setForeground(Color.WHITE);
		btnSletAflser.setFocusPainted(false);
		//btnSletAflser.setBorderPainted(false);
		btnSletAflser.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSletAflser.setBackground(new Color(174, 79, 79));
		btnSletAflser.setBounds(600, 104, 120, 25);
		panelAflosere.add(btnSletAflser);
		
		JButton btnOpretAfloser = new JButton("Opret Afl\u00F8ser");
		btnOpretAfloser.setOpaque(true);
		btnOpretAfloser.setForeground(Color.WHITE);
		btnOpretAfloser.setFocusPainted(false);
		//btnOpretAfloser.setBorderPainted(false);
		btnOpretAfloser.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnOpretAfloser.setBackground(new Color(94, 109, 126));
		btnOpretAfloser.setBounds(600, 35, 120, 25);
		panelAflosere.add(btnOpretAfloser);				
		

		init();
	}
	
	public void init() throws SQLException {
		lstPerson.setCellRenderer(new DriverListRenderer());
		updatePersonList();
}

public void updatePersonList() throws SQLException {
	List<Driver> ppl = dCtr.findAllDrivers();
	DefaultListModel<Driver> dlm = new DefaultListModel<>();
	for(int i = 0 ; i < ppl.size(); i++) {
		dlm.addElement(ppl.get(i));
	}
	this.lstPerson.setModel(dlm);
}

public void deleteDriver() throws SQLException{
	if(lstPerson.getSelectedValue() != null){
		dCtr.deleteDriver(lstPerson.getSelectedValue().getId());
		JOptionPane.showMessageDialog(null, "En Chauffør blev slettet!");
		init();
	}
	else{
		JOptionPane.showMessageDialog(null, "Der blev ikke valgt en Chauffør!", "Fejl!", JOptionPane.ERROR_MESSAGE);
	}
}

private void showDriver() throws SQLException {
	Driver d = lstPerson.getSelectedValue();
	if(d != null) {
		ViewDriver vd = new ViewDriver();
		vd.setDriver(d);
		vd.setVisible(true);
		updatePersonList();
		vd.changeTitle("Ændre Chauffør");
		vd.buttonView(1);
		init();
	}
	else{
		JOptionPane.showMessageDialog(null, "Der blev ikke valgt en Chauffør!", "Fejl!", JOptionPane.ERROR_MESSAGE);
	}
}

	public JPanel getChaufforePanel()
	{
		return contentPane;
	}
}
