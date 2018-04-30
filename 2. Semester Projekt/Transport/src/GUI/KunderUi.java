package GUI;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JList;

import java.awt.SystemColor;
import javax.swing.border.LineBorder;
import java.awt.Font;

public class KunderUi extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					KunderUi frame = new KunderUi();
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
	public KunderUi() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 744, 441);
		contentPane = new JPanel();
		contentPane.setBackground(new Color(227, 225, 224));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JPanel panel = new JPanel();
		panel.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel.setBackground(new Color(204,204,204));
		panel.setBounds(10, 11, 730, 234);
		contentPane.add(panel);
		panel.setLayout(null);
		
		JLabel lblKunder = new JLabel("Kunder");
		lblKunder.setFont(new Font("Verdana", Font.BOLD, 15));
		lblKunder.setBounds(10, 11, 81, 21);
		panel.add(lblKunder);
		
		DefaultListModel<String> model = new DefaultListModel<>();
		panel.setLayout(null);
		JList<String> list = new JList<>( model );
		list.setBounds(10, 43, 540, 181);
		list.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel.add(list);
		
		JButton btnOpret = new JButton("Opret Lastvogn");
		btnOpret.setOpaque(true);
		btnOpret.setForeground(Color.WHITE);
		btnOpret.setFocusPainted(false);
		btnOpret.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnOpret.setBackground(new Color(94, 109, 126));
		btnOpret.setBounds(580, 41, 140, 45);
		panel.add(btnOpret);
		
		JButton btnEdit = new JButton("\u00C6ndre Lastvogn");
		btnEdit.setOpaque(true);
		btnEdit.setForeground(Color.WHITE);
		btnEdit.setFocusPainted(false);
		btnEdit.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnEdit.setBackground(new Color(94, 109, 126));
		btnEdit.setBounds(580, 97, 140, 45);
		panel.add(btnEdit);
		
		JButton btnSlet = new JButton("Slet Lastvogn");
		btnSlet.setOpaque(true);
		btnSlet.setForeground(Color.WHITE);
		btnSlet.setFocusPainted(false);
		btnSlet.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSlet.setBackground(new Color(174, 79, 79));
		btnSlet.setBounds(580, 179, 140, 45);
		panel.add(btnSlet);
		model.addElement(" Kunde 1");
		model.addElement(" Kunde 2");
		model.addElement(" kunde 3");
	}
	
	public JPanel getKunderPanel()
	{
		return contentPane;
	}

}
