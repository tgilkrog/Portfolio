package GUI;
import ControlLayer.*;
import ModelLayer.Driver;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.sql.SQLException;
import java.time.format.DateTimeFormatter;
import java.awt.event.ActionEvent;
import java.awt.Color;
import java.awt.Font;
import javax.swing.border.LineBorder;
import javax.swing.JTextArea;
import javax.swing.JComboBox;

public class ViewDriver extends JFrame {

	private JPanel contentPane;
	private JTextField txtFirstName;
	private JTextField txtLastName;
	private JTextField txtAddress;
	private JTextField txtCity;
	private JTextField txtRegNr;
	private JTextField txtCarNr;
	private JTextField txtPhonenumber;
	
	private DriverUi dUi;
	private DriverController driverCtr = new DriverController();
	private Driver d;
	private JLabel lblId;
	private JLabel lblCharlieJensenTransport;
	private JButton btnUpdate;
	private JButton btnGem;
	private JComboBox<Integer> cbZipcodes;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ViewDriver frame = new ViewDriver();
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
	public ViewDriver() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		setBounds(100, 100, 515, 370);
		contentPane = new JPanel();
		contentPane.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblFornavn = new JLabel("Fornavn*");
		lblFornavn.setBounds(140, 51, 86, 14);
		contentPane.add(lblFornavn);
		
		txtFirstName = new JTextField();
		txtFirstName.setBounds(140, 68, 86, 20);
		contentPane.add(txtFirstName);
		txtFirstName.setColumns(10);
		
		JLabel lblEfternavn = new JLabel("Efternavn*");
		lblEfternavn.setBounds(140, 99, 86, 14);
		contentPane.add(lblEfternavn);
		
		txtLastName = new JTextField();
		txtLastName.setBounds(140, 113, 86, 20);
		contentPane.add(txtLastName);
		txtLastName.setColumns(10);
		
		JButton btnAnnuler = new JButton("Annuler");
		btnAnnuler.addActionListener((e) -> {
				cancel();
		});
		btnAnnuler.setBounds(396, 291, 100, 40);
		btnAnnuler.setBackground(new Color(174,79,79));
		btnAnnuler.setOpaque(true);
		btnAnnuler.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnAnnuler.setFocusPainted(false);
		btnAnnuler.setForeground(Color.WHITE);
		contentPane.add(btnAnnuler);
		
		JPanel panel = new JPanel();
		panel.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		panel.setBackground(new Color(54,73,95));
		panel.setBounds(0, 0, 509, 40);
		contentPane.add(panel);
		
		lblCharlieJensenTransport = new JLabel("Chaufføre");
		lblCharlieJensenTransport.setForeground(Color.WHITE);
		lblCharlieJensenTransport.setFont(new Font("Verdana", Font.BOLD, 15));
		panel.add(lblCharlieJensenTransport);
		
		JPanel panel_1 = new JPanel();
		panel_1.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel_1.setBackground(Color.WHITE);
		panel_1.setBounds(10, 51, 120, 156);
		contentPane.add(panel_1);
		
		JLabel lblAddresse = new JLabel("Addresse*");
		lblAddresse.setBounds(238, 51, 84, 14);
		contentPane.add(lblAddresse);
		
		txtAddress = new JTextField();
		txtAddress.setBounds(236, 68, 86, 20);
		contentPane.add(txtAddress);
		txtAddress.setColumns(10);
		
		JLabel lblBy = new JLabel("By");
		lblBy.setBounds(238, 99, 46, 14);
		contentPane.add(lblBy);
		
		txtCity = new JTextField();
		txtCity.setEditable(false);
		txtCity.setBounds(236, 113, 86, 20);
		contentPane.add(txtCity);
		txtCity.setColumns(10);
		
		JLabel lblZipcode = new JLabel("ZipCode*");
		lblZipcode.setBounds(238, 144, 84, 14);
		contentPane.add(lblZipcode);
		
		JLabel lblRegistreringsNr = new JLabel("Registrerings nr.*");
		lblRegistreringsNr.setBounds(335, 51, 103, 14);
		contentPane.add(lblRegistreringsNr);
		
		txtRegNr = new JTextField();
		txtRegNr.setBounds(335, 68, 86, 20);
		contentPane.add(txtRegNr);
		txtRegNr.setColumns(10);
		
		JLabel lblBilNr = new JLabel("Bil nr.*");
		lblBilNr.setBounds(335, 99, 86, 14);
		contentPane.add(lblBilNr);
		
		txtCarNr = new JTextField();
		txtCarNr.setBounds(335, 113, 86, 20);
		contentPane.add(txtCarNr);
		txtCarNr.setColumns(10);
		
		JLabel lblBemarkninger = new JLabel("Bem\u00E6rkninger");
		lblBemarkninger.setBounds(140, 203, 103, 14);
		contentPane.add(lblBemarkninger);
		
		JTextArea textArea = new JTextArea();
		textArea.setBounds(140, 216, 226, 114);
		textArea.setBorder(new LineBorder(new Color(0, 0, 0)));
		contentPane.add(textArea);
		
		btnGem = new JButton("Opret");
		btnGem.addActionListener((e) -> {
		try {
			createDriver();
		} 
		catch (NumberFormatException | SQLException e1) {
			e1.printStackTrace();
		} 
		//JOptionPane.showMessageDialog(null, "En Chauffør blev Oprettet!");
		});
		btnGem.setBackground(new Color(94,109,126));
		btnGem.setOpaque(true);
		btnGem.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnGem.setFocusPainted(false);
		btnGem.setForeground(Color.WHITE);
		btnGem.setBounds(396, 241, 100, 40);
		contentPane.add(btnGem);
		
		JLabel lblTelefon = new JLabel("Telefon*");
		lblTelefon.setBounds(140, 144, 86, 14);
		contentPane.add(lblTelefon);
		
		txtPhonenumber = new JTextField();
		txtPhonenumber.setBounds(140, 160, 86, 20);
		contentPane.add(txtPhonenumber);
		txtPhonenumber.setColumns(10);
		
		btnUpdate = new JButton("Ændre");
		btnUpdate.addActionListener((e) -> {
			try {
				updateDriver();
			} 
			catch (NumberFormatException | SQLException e1) {
				e1.printStackTrace();
			}
			JOptionPane.showMessageDialog(null, "En Chauffør blev Opdateret!");
			cancel();
		});
		btnUpdate.setOpaque(true);
		btnUpdate.setForeground(Color.WHITE);
		btnUpdate.setFocusPainted(false);
		btnUpdate.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnUpdate.setBackground(new Color(94, 109, 126));
		btnUpdate.setBounds(396, 241, 100, 40);
		contentPane.add(btnUpdate);
		
		JLabel lblNewLabel = new JLabel("Dem med *, skal udfyldes");
		lblNewLabel.setBounds(345, 193, 164, 14);
		contentPane.add(lblNewLabel);
		
		Integer[] zipcodes = {9000, 9240, 9530, 9541, 9600};
		cbZipcodes = new JComboBox(zipcodes);
		cbZipcodes.setBounds(238, 160, 84, 20);
		contentPane.add(cbZipcodes);
	}
	
	private void cancel(){
		this.setVisible(false);
		this.dispose();
	}
	
	public void createDriver() throws NumberFormatException, SQLException{
		int id = 0;
		try{
			if(txtFirstName.getText().equals("") || txtLastName.getText().equals("") || txtAddress.getText().equals("")){
				JOptionPane.showMessageDialog(null, "Et felt er ikke blevet udfyldt!");
			}
			else{
				driverCtr.createDriver(txtFirstName.getText(), txtLastName.getText(), Integer.parseInt(txtPhonenumber.getText()), 
				txtAddress.getText(), (int) cbZipcodes.getSelectedItem(), 
				Integer.parseInt(txtRegNr.getText()), Integer.parseInt(txtCarNr.getText()), true, id);
				JOptionPane.showMessageDialog(null, "En Chauffør blev Oprettet!");
				cancel();
			}
		}
		catch(NumberFormatException e){
			JOptionPane.showMessageDialog(null, "Et Felt er ikke blevet udfyldt!");
		}
	}
	public void updateDriver() throws NumberFormatException, SQLException{
		driverCtr.updateDriver(txtFirstName.getText(), txtLastName.getText(), Integer.parseInt(txtPhonenumber.getText()),
				txtAddress.getText(), (int) cbZipcodes.getSelectedItem(), 
				Integer.parseInt(txtRegNr.getText()), Integer.parseInt(txtCarNr.getText()), this.d.getId());
	}
	
	public void setDriver(Driver d) {
		this.d= d;
		this.txtFirstName.setText(d.getFirstName());
		this.txtLastName.setText(d.getLastName());
		this.txtPhonenumber.setText(Integer.toString(d.getPhonenumber()));
		this.txtAddress.setText(d.getAddress());
		this.txtCity.setText(d.getCity());
		this.cbZipcodes.setSelectedItem(d.getZipCode());;
		//this.txtZipCode.setText(Integer.toString(d.getZipCode()));
		this.txtRegNr.setText(Integer.toString(d.getRegistreringsNr()));
		this.txtCarNr.setText(Integer.toString(d.getCarNr()));
	}
	
	public void changeTitle(String tekst){
		lblCharlieJensenTransport.setText(tekst);
	}
	
	public void buttonView(int number){
		btnUpdate.setVisible(false);
		btnGem.setVisible(false);
		
		switch (number) {
		case 1: btnUpdate.setVisible(true);
			break;
		case 2: btnGem.setVisible(true);
			break;
		default: 
			break;
		}
	}
}
