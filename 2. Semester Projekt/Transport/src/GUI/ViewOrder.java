package GUI;
import ControlLayer.*;
import ModelLayer.Order;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.sql.SQLException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

import org.jdesktop.swingx.JXDatePicker;

import javax.swing.JComboBox;

public class ViewOrder extends JFrame {

	private JPanel contentPane;
	private JTextField txtProduct;
	private JTextField txtWeight;
	private JTextField txtDate;
	private JTextField txtHeight;
	
	private Order o;
	JXDatePicker picker;
	private final static DateFormat format = new SimpleDateFormat("yyyy-MM-dd");

	private OrderController oCtr = new OrderController();
	private OrdreUi oUi;
	private JComboBox cbStart;
	private JComboBox cbEnd;
	private JButton btnUpdate;
	private JButton btnSave;
	private JLabel lblNewLabel;
	private JLabel lblCharlieJensenTransport;;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ViewOrder frame = new ViewOrder();
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
	public ViewOrder() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		setBounds(100, 100, 515, 370);
		
		contentPane = new JPanel();
		contentPane.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblProduct = new JLabel("Produkt*");
		lblProduct.setBounds(61, 81, 86, 14);
		contentPane.add(lblProduct);
		
		txtProduct = new JTextField();
		txtProduct.setBounds(61, 96, 86, 20);
		contentPane.add(txtProduct);
		txtProduct.setColumns(10);
		
		JLabel lblWeight = new JLabel("V\u00E6gt*");
		lblWeight.setBounds(61, 131, 86, 14);
		contentPane.add(lblWeight);
		
		txtWeight = new JTextField();
		txtWeight.setBounds(61, 147, 86, 20);
		contentPane.add(txtWeight);
		txtWeight.setColumns(10);
		
		JButton btnCancel = new JButton("Annuler");
		btnCancel.addActionListener((e) -> {
				cancel();
		});
		btnCancel.setBounds(396, 291, 100, 40);
		btnCancel.setBackground(new Color(174,79,79));
		btnCancel.setOpaque(true);
		btnCancel.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnCancel.setFocusPainted(false);
		btnCancel.setForeground(Color.WHITE);
		contentPane.add(btnCancel);
		
		JPanel panel = new JPanel();
		panel.setBorder(new LineBorder(new Color(0, 0, 0), 2));
		panel.setBackground(new Color(54,73,95));
		panel.setBounds(0, 0, 509, 40);
		contentPane.add(panel);
		
		lblCharlieJensenTransport = new JLabel("Charlie Jensen Transport");
		lblCharlieJensenTransport.setForeground(Color.WHITE);
		lblCharlieJensenTransport.setFont(new Font("Verdana", Font.BOLD, 15));
		panel.add(lblCharlieJensenTransport);
		
		JLabel lblStartAddress = new JLabel("Start Addresse");
		lblStartAddress.setBounds(190, 81, 100, 14);
		contentPane.add(lblStartAddress);
		
		JLabel lblEndAddress = new JLabel("Slut Addresse");
		lblEndAddress.setBounds(192, 131, 84, 14);
		contentPane.add(lblEndAddress);
		
		JLabel lblDate = new JLabel("Leverings Dato");
		lblDate.setBounds(192, 177, 164, 14);
		contentPane.add(lblDate);
		
		picker = new JXDatePicker();
		picker.setDate(Calendar.getInstance().getTime());
		picker.setFormats(new SimpleDateFormat("yyyy.MM.dd"));
		picker.setBounds(192, 191, 121, 20);
		contentPane.add(picker);
		
		txtDate = new JTextField();
		txtDate.setEditable(false);
		txtDate.setBounds(192, 191, 86, 20);
		contentPane.add(txtDate);
		txtDate.setColumns(10);
		txtDate.setVisible(false);
		
		btnSave = new JButton("Opret Ordre");
		btnSave.addActionListener((e) -> {
				try {
					createOrder();
				} catch (NumberFormatException | SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		});
		btnSave.setBackground(new Color(94,109,126));
		btnSave.setOpaque(true);
		btnSave.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSave.setFocusPainted(false);
		btnSave.setForeground(Color.WHITE);
		btnSave.setBounds(396, 241, 100, 40);
		contentPane.add(btnSave);
		
		JLabel lblHeight = new JLabel("H\u00F8jde*");
		lblHeight.setBounds(61, 177, 71, 14);
		contentPane.add(lblHeight);
		
		txtHeight = new JTextField();
		txtHeight.setText("4.20");
		txtHeight.setBounds(61, 191, 86, 20);
		contentPane.add(txtHeight);
		txtHeight.setColumns(10);
		
		btnUpdate = new JButton("Gem \u00E6ndringer");
		btnUpdate.addActionListener((e) -> {
				try {
					updateOrder();				
				} catch (NumberFormatException | SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}

		});
		btnUpdate.setOpaque(true);
		btnUpdate.setForeground(Color.WHITE);
		btnUpdate.setFocusPainted(false);
		btnUpdate.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnUpdate.setBackground(new Color(94, 109, 126));
		btnUpdate.setBounds(396, 240, 100, 40);
		contentPane.add(btnUpdate);
		
		String[] city = {"Sørup", "Aalborg", "Aars", "Hirtshals", "Viborg", "Herning", "Holstebro", "Frederikshavn"};
		
		cbStart = new JComboBox(city);
		cbStart.setBounds(190, 96, 123, 20);
		contentPane.add(cbStart);
		
		cbEnd = new JComboBox(city);
		cbEnd.setBounds(190, 147, 123, 20);
		contentPane.add(cbEnd);
		
		lblNewLabel = new JLabel("Dem med *, skal udfyldes");
		lblNewLabel.setBounds(10, 51, 147, 14);
		contentPane.add(lblNewLabel);
	}
	
	private void cancel(){
		this.setVisible(false);
		this.dispose();	
	}
	
	public void createOrder() throws NumberFormatException, SQLException{
		int id = 0;
		
		try{
			if(txtProduct.getText().equals("")){
				JOptionPane.showMessageDialog(null, "Et felt er ikke blevet udfyldt");
			}
			else if(cbStart.getSelectedItem().equals(cbEnd.getSelectedItem())){
				JOptionPane.showMessageDialog(null, "start By og slut by må ikke være ens");
			}
			else{
				oCtr.createOrder(txtProduct.getText(), Double.parseDouble(txtWeight.getText()), Double.parseDouble(txtHeight.getText()), 
				cbStart.getSelectedItem().toString(), cbEnd.getSelectedItem().toString(), format.format(picker.getDate()), id);
				JOptionPane.showMessageDialog(null, "En Ordre blev Oprettet!");
				cancel();
			}
		}
		catch(NumberFormatException e){
			JOptionPane.showMessageDialog(null, "Et felt blev ikke udfyldt");
		}
	}
	
	public void updateOrder() throws NumberFormatException, SQLException{
		if(cbStart.getSelectedItem().equals(cbEnd.getSelectedItem())){
			JOptionPane.showMessageDialog(null, "start By og slut by må ikke være ens");
			}
		else{
			oCtr.updateOrder(txtProduct.getText(), Double.parseDouble(txtWeight.getText()), Double.parseDouble(txtHeight.getText()), 
				cbStart.getSelectedItem().toString(), cbEnd.getSelectedItem().toString(), format.format(picker.getDate()), this.o.getId());
		
			oUi = new OrdreUi();
			oUi.init();
			
			JOptionPane.showMessageDialog(null, "En Ordre blev Opdateret!");
			cancel();
		}
	}
	
	public void setOrder(Order o) throws ParseException {
		this.o = o;
		txtProduct.setText(o.getProduct());
		txtWeight.setText(Double.toString(o.getWeight()));
		txtHeight.setText(Double.toString(o.getHeight()));
		cbStart.setSelectedItem(o.getStartAddress());
		cbEnd.setSelectedItem(o.getEndAddress());
		txtDate.setText(o.getDate());
		
		java.util.Date date = format.parse(o.getDate());
		picker.setDate(date);
	}
	
	public void buttonView(int number){
		btnUpdate.setVisible(false);
		btnSave.setVisible(false);
		
		switch (number) {
		case 1: btnUpdate.setVisible(true);
				lblCharlieJensenTransport.setText("Ændre Ordre");
			break;
		case 2: btnSave.setVisible(true);
				lblCharlieJensenTransport.setText("Opret Ordre");
			break;
		default: 
			break;
		}
	}
}