using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_124_S23_L16_Persistent_Data_JSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Member> _members = new List<Member>();
        Member currentMember = null;

        public MainWindow()
        {
            InitializeComponent();
            lbMembers.ItemsSource = _members;

            //Preload();

        } // MainWindow

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonManager = JsonSerializer.Serialize(_members, jso);

            File.WriteAllText(Data.MemberFilePath, jsonManager);
        } // btnSave_Click

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string listFromFile = File.ReadAllText(Data.MemberFilePath);
            _members = JsonSerializer.Deserialize<List<Member>>(listFromFile);

            MembersListRefresh();
        } // btnLoad_Click





        public void Preload()
        {
            // Adding members
            _members.Add(new Member("William Cram"));
            _members.Add(new Member("Josh Emery"));

            // Adding Transactions for members
            Member currentMember = _members[0];
            currentMember.AddTransaction(new Transaction("Tea", 3.25, 3));
            currentMember.AddTransaction(new Transaction("Coffee", 2.50, 1));
            currentMember.AddTransaction(new Transaction("Teriyaki", 14.50, 2));

            // Adding Transactions for members
            currentMember = _members[1];
            currentMember.AddTransaction(new Transaction("Coffee", 7.20, 1));
            currentMember.AddTransaction(new Transaction("Breakfast", 7.00, 2));
            currentMember.AddTransaction(new Transaction("Sandwich", 5.00, 1));

        } // Preload();

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;

            _members.Add(new Member(name));

            MembersListRefresh();
        } // btnAddUser_Click

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

            if(currentMember != null)
            {
                string name = txtProductName.Text;
                double price = double.Parse(txtPrice.Text);
                int qty = int.Parse(txtQty.Text);

                Transaction transaction = new Transaction(name, price, qty);

                currentMember.AddTransaction(transaction);

                TransactionListRefresh();
            }

        } // btnAddItem_Click

        private void lbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbMembers.SelectedItem != null)
            {
                currentMember = (Member)lbMembers.SelectedItem;
                lblMemberName.Content = currentMember.Name;

                lvTransactions.ItemsSource = currentMember.Transactions;

                TransactionListRefresh();
            }
        } // lbMembers_SelectionChanged

        // Helper Methods
        public void TransactionListRefresh()
        {
            lvTransactions.Items.Refresh();
            
        } // LvTransactionRefresh

        public void MembersListRefresh()
        {
            lbMembers.ItemsSource = _members;
            lbMembers.Items.Refresh();
        } // LvTransactionRefresh


    } // class

} // namespace
