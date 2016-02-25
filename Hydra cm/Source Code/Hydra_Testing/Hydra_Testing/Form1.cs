using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HydraAPI;
using System.Diagnostics;

namespace Hydra_Testing
{
    public partial class Form1 : Form
    {
        HydraAPI.Initialize initialize = new HydraAPI.Initialize(@"C:\hadoop-2.7.2" , @"C:\zookeeper");
        public Form1()
        {
            InitializeComponent();
        }

    
        private void Start_Hadoop_Click(object sender, EventArgs e)
        {
            Console.Write("hello");
            initialize.start_hadoop();
            
        }

        private void Rebalance_Cluster_Click(object sender, EventArgs e)
        {
            //initialize.rebalanceCluster(Rebalance_Cluster_text.Text);
            initialize.rebalanceCluster(Rebalance_Cluster_text.Text);

        }

        private void Format_Namenode_Click(object sender, EventArgs e)
        {
            initialize.formatNameNode();
        }

        private void Set_replication_Click(object sender, EventArgs e)
        {
            initialize.setReplication(Set_replication_Number.Text , Set_replication_path.Text);
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
           
            initialize.setup_hadoop_configs("192.168.0.12", "3");
            //initialize.formatNameNode();
        }

        private void Make_directory_Click(object sender, EventArgs e)
        {
           
        }

        private void Populate_Slave_files_Click(object sender, EventArgs e)
        {
           

            initialize.populate_slaves_file_network();
            initialize.populate_slaves_file_local();
        }

        private void HA_setup_hadoop_configs_Click(object sender, EventArgs e)
        {

            string[] namenode_Ipad = new string[3];
            namenode_Ipad[0] = textBox1.Text;
            namenode_Ipad[1] = textBox2.Text;

            string[] journal_node = new string[3];
            journal_node[0] = textBox3.Text;
            journal_node[1] = textBox4.Text;
            journal_node[2] = textBox5.Text;

            MessageBox.Show(initialize.HA_setup_hadoop_configs_with(namenode_Ipad, journal_node, textBox6.Text)) ;

            //initialize.HA_setup_hadoop_configs_with(namenode_Ipad,journal_node, "3", @"C:\journal_folder");


        }

        private void HA_formatJournalNodes_Click(object sender, EventArgs e)
        {
            initialize.HA_formatJournalNodes();
        }

        private void HA_getLatestCheckpoint_Click(object sender, EventArgs e)
        {
            initialize.HA_getLatestCheckpoint();
        }

        private void HA_startJournalNode_Click(object sender, EventArgs e)
        {
            initialize.HA_formatJournalNodes();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void HA_checkNNState_Click(object sender, EventArgs e)
        {
            initialize.HA_checkNNState(HA_checknnstate_serviceID.Text);
        }

        private void Set_Active_node_Click(object sender, EventArgs e)
        {
            MessageBox.Show(initialize.HA_setNNToActive(set_active_node_text.Text));
            
        }

        private void Set_SingleNode_Click(object sender, EventArgs e)
        {

            MessageBox.Show(initialize.setup_hadoop_configs(SN_NamenodeIP.Text, SN_replication_factor.Text));

        }

        private void Slaves_Click(object sender, EventArgs e)
        {

            initialize.populate_slaves_file_network();
            initialize.populate_slaves_file_local();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            initialize.clear_slaves_file();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JN_combobox.Items.Add(add_to_zk_or_jn.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZK_combobox.Items.Add(add_to_zk_or_jn.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] NN = new string[NN_combobox.Items.Count];
            string[] JN = new string[JN_combobox.Items.Count];
            string[] ZK = new string[ZK_combobox.Items.Count];


            for (int i = 0; i < NN_combobox.Items.Count; i++)
            {

                NN[i] = NN_combobox.Items[i].ToString();
            }
            for (int i = 0; i < JN_combobox.Items.Count; i++)
            {

                JN[i] = JN_combobox.Items[i].ToString();
            }
            for (int i = 0; i < ZK_combobox.Items.Count; i++)
            {

                ZK[i] = ZK_combobox.Items[i].ToString();
            }


                initialize.ZK_setup_hadoop_configs_with_ha(NN, JN, ZK, rep_factor_textbox.Text, jndir_textbox.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NN_combobox.Items.Add(add_to_zk_or_jn.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            initialize.ZK_setup_znode();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            initialize.ZK_start_zkfc();
        }

        private void button9_Click(object sender, EventArgs e)
        {
             MessageBox.Show(initialize.HA_setNNToActive(set_active_node_text.Text));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SetupZK_NN_Combobox.Items.Add(SetupZK_NN_textbox.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string[] ServerIP = new string[SetupZK_NN_Combobox.Items.Count];


            for (int i = 0; i < SetupZK_NN_Combobox.Items.Count; i++)
            {

                ServerIP[i] = SetupZK_NN_Combobox.Items[i].ToString();
            }

            initialize.ZK_setup_zookeeper(ServerIP , SetupZK_Serverid_text.Text, SetupZK_MaxClient_textbox.Text);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            initialize.HA_startJournalNode();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            initialize.ZK_Server();
        }

       





        








    }
}
