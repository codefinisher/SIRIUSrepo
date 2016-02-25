namespace Hydra_Testing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start_Hadoop = new System.Windows.Forms.Button();
            this.Rebalance_Cluster = new System.Windows.Forms.Button();
            this.Rebalance_Cluster_text = new System.Windows.Forms.TextBox();
            this.Format_Namenode = new System.Windows.Forms.Button();
            this.Set_replication = new System.Windows.Forms.Button();
            this.Set_replication_Number = new System.Windows.Forms.TextBox();
            this.Set_replication_path = new System.Windows.Forms.TextBox();
            this.HA_setup_hadoop_configs = new System.Windows.Forms.Button();
            this.HA_getLatestCheckpoint = new System.Windows.Forms.Button();
            this.HA_startJournalNode = new System.Windows.Forms.Button();
            this.HA_checkNNState = new System.Windows.Forms.Button();
            this.HA_checknnstate_serviceID = new System.Windows.Forms.TextBox();
            this.Set_Active_node = new System.Windows.Forms.Button();
            this.set_active_node_text = new System.Windows.Forms.TextBox();
            this.Set_SingleNode = new System.Windows.Forms.Button();
            this.SN_NamenodeIP = new System.Windows.Forms.TextBox();
            this.SN_replication_factor = new System.Windows.Forms.TextBox();
            this.Slaves = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.JN_combobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ZK_combobox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.add_to_zk_or_jn = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.NN_combobox = new System.Windows.Forms.ComboBox();
            this.rep_factor_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.jndir_textbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SetupZK_NN_Combobox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SetupZK_NN_textbox = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.SetupZK_Serverid_text = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SetupZK_MaxClient_textbox = new System.Windows.Forms.TextBox();
            this.MaxClient = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_Hadoop
            // 
            this.Start_Hadoop.Location = new System.Drawing.Point(69, 24);
            this.Start_Hadoop.Name = "Start_Hadoop";
            this.Start_Hadoop.Size = new System.Drawing.Size(123, 23);
            this.Start_Hadoop.TabIndex = 2;
            this.Start_Hadoop.Text = "Start_Hadoop";
            this.Start_Hadoop.UseVisualStyleBackColor = true;
            this.Start_Hadoop.Click += new System.EventHandler(this.Start_Hadoop_Click);
            // 
            // Rebalance_Cluster
            // 
            this.Rebalance_Cluster.Location = new System.Drawing.Point(225, 71);
            this.Rebalance_Cluster.Name = "Rebalance_Cluster";
            this.Rebalance_Cluster.Size = new System.Drawing.Size(123, 23);
            this.Rebalance_Cluster.TabIndex = 3;
            this.Rebalance_Cluster.Text = "Rebalance_Cluster";
            this.Rebalance_Cluster.UseVisualStyleBackColor = true;
            this.Rebalance_Cluster.Click += new System.EventHandler(this.Rebalance_Cluster_Click);
            // 
            // Rebalance_Cluster_text
            // 
            this.Rebalance_Cluster_text.Location = new System.Drawing.Point(69, 73);
            this.Rebalance_Cluster_text.Name = "Rebalance_Cluster_text";
            this.Rebalance_Cluster_text.Size = new System.Drawing.Size(123, 20);
            this.Rebalance_Cluster_text.TabIndex = 4;
            // 
            // Format_Namenode
            // 
            this.Format_Namenode.Location = new System.Drawing.Point(225, 23);
            this.Format_Namenode.Name = "Format_Namenode";
            this.Format_Namenode.Size = new System.Drawing.Size(123, 23);
            this.Format_Namenode.TabIndex = 5;
            this.Format_Namenode.Text = "Format_Namenode";
            this.Format_Namenode.UseVisualStyleBackColor = true;
            this.Format_Namenode.Click += new System.EventHandler(this.Format_Namenode_Click);
            // 
            // Set_replication
            // 
            this.Set_replication.Location = new System.Drawing.Point(368, 182);
            this.Set_replication.Name = "Set_replication";
            this.Set_replication.Size = new System.Drawing.Size(123, 23);
            this.Set_replication.TabIndex = 6;
            this.Set_replication.Text = "Set_replication";
            this.Set_replication.UseVisualStyleBackColor = true;
            this.Set_replication.Click += new System.EventHandler(this.Set_replication_Click);
            // 
            // Set_replication_Number
            // 
            this.Set_replication_Number.Location = new System.Drawing.Point(69, 185);
            this.Set_replication_Number.Name = "Set_replication_Number";
            this.Set_replication_Number.Size = new System.Drawing.Size(123, 20);
            this.Set_replication_Number.TabIndex = 7;
            this.Set_replication_Number.Text = "Number of Replication";
            // 
            // Set_replication_path
            // 
            this.Set_replication_path.Location = new System.Drawing.Point(215, 185);
            this.Set_replication_path.Name = "Set_replication_path";
            this.Set_replication_path.Size = new System.Drawing.Size(123, 20);
            this.Set_replication_path.TabIndex = 8;
            this.Set_replication_path.Text = "Path";
            // 
            // HA_setup_hadoop_configs
            // 
            this.HA_setup_hadoop_configs.Location = new System.Drawing.Point(225, 256);
            this.HA_setup_hadoop_configs.Name = "HA_setup_hadoop_configs";
            this.HA_setup_hadoop_configs.Size = new System.Drawing.Size(75, 139);
            this.HA_setup_hadoop_configs.TabIndex = 29;
            this.HA_setup_hadoop_configs.Text = "High Availability  With Manual Failover";
            this.HA_setup_hadoop_configs.UseVisualStyleBackColor = true;
            this.HA_setup_hadoop_configs.Click += new System.EventHandler(this.HA_setup_hadoop_configs_Click);
            // 
            // HA_getLatestCheckpoint
            // 
            this.HA_getLatestCheckpoint.Location = new System.Drawing.Point(736, 335);
            this.HA_getLatestCheckpoint.Name = "HA_getLatestCheckpoint";
            this.HA_getLatestCheckpoint.Size = new System.Drawing.Size(123, 44);
            this.HA_getLatestCheckpoint.TabIndex = 31;
            this.HA_getLatestCheckpoint.Text = "HA Bootstrap Standy / Latest Checkpoint";
            this.HA_getLatestCheckpoint.UseVisualStyleBackColor = true;
            this.HA_getLatestCheckpoint.Click += new System.EventHandler(this.HA_getLatestCheckpoint_Click);
            // 
            // HA_startJournalNode
            // 
            this.HA_startJournalNode.Location = new System.Drawing.Point(736, 250);
            this.HA_startJournalNode.Name = "HA_startJournalNode";
            this.HA_startJournalNode.Size = new System.Drawing.Size(123, 23);
            this.HA_startJournalNode.TabIndex = 32;
            this.HA_startJournalNode.Text = "Initialize Shared Edits";
            this.HA_startJournalNode.UseVisualStyleBackColor = true;
            this.HA_startJournalNode.Click += new System.EventHandler(this.HA_startJournalNode_Click);
            // 
            // HA_checkNNState
            // 
            this.HA_checkNNState.Location = new System.Drawing.Point(736, 511);
            this.HA_checkNNState.Name = "HA_checkNNState";
            this.HA_checkNNState.Size = new System.Drawing.Size(123, 23);
            this.HA_checkNNState.TabIndex = 33;
            this.HA_checkNNState.Text = "HA_checkNNState";
            this.HA_checkNNState.UseVisualStyleBackColor = true;
            this.HA_checkNNState.Click += new System.EventHandler(this.HA_checkNNState_Click);
            // 
            // HA_checknnstate_serviceID
            // 
            this.HA_checknnstate_serviceID.Location = new System.Drawing.Point(589, 514);
            this.HA_checknnstate_serviceID.Name = "HA_checknnstate_serviceID";
            this.HA_checknnstate_serviceID.Size = new System.Drawing.Size(118, 20);
            this.HA_checknnstate_serviceID.TabIndex = 34;
            // 
            // Set_Active_node
            // 
            this.Set_Active_node.Location = new System.Drawing.Point(736, 413);
            this.Set_Active_node.Name = "Set_Active_node";
            this.Set_Active_node.Size = new System.Drawing.Size(123, 23);
            this.Set_Active_node.TabIndex = 35;
            this.Set_Active_node.Text = "NN to Active";
            this.Set_Active_node.UseVisualStyleBackColor = true;
            this.Set_Active_node.Click += new System.EventHandler(this.Set_Active_node_Click);
            // 
            // set_active_node_text
            // 
            this.set_active_node_text.Location = new System.Drawing.Point(589, 432);
            this.set_active_node_text.Name = "set_active_node_text";
            this.set_active_node_text.Size = new System.Drawing.Size(118, 20);
            this.set_active_node_text.TabIndex = 36;
            // 
            // Set_SingleNode
            // 
            this.Set_SingleNode.Location = new System.Drawing.Point(782, 24);
            this.Set_SingleNode.Name = "Set_SingleNode";
            this.Set_SingleNode.Size = new System.Drawing.Size(102, 23);
            this.Set_SingleNode.TabIndex = 37;
            this.Set_SingleNode.Text = "Set_single_Node";
            this.Set_SingleNode.UseVisualStyleBackColor = true;
            this.Set_SingleNode.Click += new System.EventHandler(this.Set_SingleNode_Click);
            // 
            // SN_NamenodeIP
            // 
            this.SN_NamenodeIP.Location = new System.Drawing.Point(531, 26);
            this.SN_NamenodeIP.Name = "SN_NamenodeIP";
            this.SN_NamenodeIP.Size = new System.Drawing.Size(100, 20);
            this.SN_NamenodeIP.TabIndex = 38;
            this.SN_NamenodeIP.Text = "Namenode IP";
            // 
            // SN_replication_factor
            // 
            this.SN_replication_factor.Location = new System.Drawing.Point(637, 26);
            this.SN_replication_factor.Name = "SN_replication_factor";
            this.SN_replication_factor.Size = new System.Drawing.Size(100, 20);
            this.SN_replication_factor.TabIndex = 39;
            this.SN_replication_factor.Text = "Replication Factor";
            // 
            // Slaves
            // 
            this.Slaves.Location = new System.Drawing.Point(72, 124);
            this.Slaves.Name = "Slaves";
            this.Slaves.Size = new System.Drawing.Size(106, 23);
            this.Slaves.TabIndex = 40;
            this.Slaves.Text = "Populate Slaves";
            this.Slaves.UseVisualStyleBackColor = true;
            this.Slaves.Click += new System.EventHandler(this.Slaves_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 281);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 42;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(69, 307);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 43;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(69, 333);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 44;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(69, 359);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "NN1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "NN2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "J1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "J2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "J3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "ClearSlaves";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(69, 385);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Replication";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 142);
            this.button2.TabIndex = 55;
            this.button2.Text = "Zookeeper High Availability / Auto Failover";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "NN";
            // 
            // JN_combobox
            // 
            this.JN_combobox.FormattingEnabled = true;
            this.JN_combobox.Location = new System.Drawing.Point(68, 503);
            this.JN_combobox.Name = "JN_combobox";
            this.JN_combobox.Size = new System.Drawing.Size(100, 21);
            this.JN_combobox.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 506);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "JN";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 531);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "ZK";
            // 
            // ZK_combobox
            // 
            this.ZK_combobox.FormattingEnabled = true;
            this.ZK_combobox.Location = new System.Drawing.Point(68, 531);
            this.ZK_combobox.Name = "ZK_combobox";
            this.ZK_combobox.Size = new System.Drawing.Size(100, 21);
            this.ZK_combobox.TabIndex = 63;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 502);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 23);
            this.button3.TabIndex = 64;
            this.button3.Text = "JN_Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 531);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 65;
            this.button4.Text = "ZK_ad";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // add_to_zk_or_jn
            // 
            this.add_to_zk_or_jn.Location = new System.Drawing.Point(69, 451);
            this.add_to_zk_or_jn.Name = "add_to_zk_or_jn";
            this.add_to_zk_or_jn.Size = new System.Drawing.Size(100, 20);
            this.add_to_zk_or_jn.TabIndex = 66;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(174, 473);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 23);
            this.button5.TabIndex = 67;
            this.button5.Text = "NN_Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // NN_combobox
            // 
            this.NN_combobox.FormattingEnabled = true;
            this.NN_combobox.Location = new System.Drawing.Point(68, 476);
            this.NN_combobox.Name = "NN_combobox";
            this.NN_combobox.Size = new System.Drawing.Size(100, 21);
            this.NN_combobox.TabIndex = 68;
            // 
            // rep_factor_textbox
            // 
            this.rep_factor_textbox.Location = new System.Drawing.Point(68, 558);
            this.rep_factor_textbox.Name = "rep_factor_textbox";
            this.rep_factor_textbox.Size = new System.Drawing.Size(100, 20);
            this.rep_factor_textbox.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-7, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Rep Factor";
            // 
            // jndir_textbox
            // 
            this.jndir_textbox.Location = new System.Drawing.Point(68, 584);
            this.jndir_textbox.Name = "jndir_textbox";
            this.jndir_textbox.Size = new System.Drawing.Size(100, 20);
            this.jndir_textbox.TabIndex = 71;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 587);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "JNDIR";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(387, 413);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 73;
            this.button6.Text = "FormatZK";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(387, 454);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 74;
            this.button7.Text = "StartZKFC";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(736, 284);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(123, 23);
            this.button8.TabIndex = 75;
            this.button8.Text = "Start Journal Node";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(736, 451);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(123, 23);
            this.button9.TabIndex = 76;
            this.button9.Text = "NN To Standby";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(607, 247);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 139);
            this.button10.TabIndex = 77;
            this.button10.Text = "Setup Zookeeper";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // SetupZK_NN_Combobox
            // 
            this.SetupZK_NN_Combobox.FormattingEnabled = true;
            this.SetupZK_NN_Combobox.Location = new System.Drawing.Point(439, 276);
            this.SetupZK_NN_Combobox.Name = "SetupZK_NN_Combobox";
            this.SetupZK_NN_Combobox.Size = new System.Drawing.Size(145, 21);
            this.SetupZK_NN_Combobox.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(410, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "ZK";
            // 
            // SetupZK_NN_textbox
            // 
            this.SetupZK_NN_textbox.Location = new System.Drawing.Point(439, 250);
            this.SetupZK_NN_textbox.Name = "SetupZK_NN_textbox";
            this.SetupZK_NN_textbox.Size = new System.Drawing.Size(100, 20);
            this.SetupZK_NN_textbox.TabIndex = 80;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(545, 248);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(39, 23);
            this.button11.TabIndex = 81;
            this.button11.Text = "ZK";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // SetupZK_Serverid_text
            // 
            this.SetupZK_Serverid_text.Location = new System.Drawing.Point(439, 316);
            this.SetupZK_Serverid_text.Name = "SetupZK_Serverid_text";
            this.SetupZK_Serverid_text.Size = new System.Drawing.Size(145, 20);
            this.SetupZK_Serverid_text.TabIndex = 82;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(384, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 83;
            this.label13.Text = "ServerID";
            // 
            // SetupZK_MaxClient_textbox
            // 
            this.SetupZK_MaxClient_textbox.Location = new System.Drawing.Point(439, 348);
            this.SetupZK_MaxClient_textbox.Name = "SetupZK_MaxClient_textbox";
            this.SetupZK_MaxClient_textbox.Size = new System.Drawing.Size(145, 20);
            this.SetupZK_MaxClient_textbox.TabIndex = 84;
            // 
            // MaxClient
            // 
            this.MaxClient.AutoSize = true;
            this.MaxClient.Location = new System.Drawing.Point(377, 351);
            this.MaxClient.Name = "MaxClient";
            this.MaxClient.Size = new System.Drawing.Size(56, 13);
            this.MaxClient.TabIndex = 85;
            this.MaxClient.Text = "Max Client";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(380, 501);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(104, 23);
            this.button12.TabIndex = 86;
            this.button12.Text = "StartZK Server";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 653);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.MaxClient);
            this.Controls.Add(this.SetupZK_MaxClient_textbox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SetupZK_Serverid_text);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.SetupZK_NN_textbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SetupZK_NN_Combobox);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.jndir_textbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rep_factor_textbox);
            this.Controls.Add(this.NN_combobox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.add_to_zk_or_jn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ZK_combobox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.JN_combobox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Slaves);
            this.Controls.Add(this.SN_replication_factor);
            this.Controls.Add(this.SN_NamenodeIP);
            this.Controls.Add(this.Set_SingleNode);
            this.Controls.Add(this.set_active_node_text);
            this.Controls.Add(this.Set_Active_node);
            this.Controls.Add(this.HA_checknnstate_serviceID);
            this.Controls.Add(this.HA_checkNNState);
            this.Controls.Add(this.HA_startJournalNode);
            this.Controls.Add(this.HA_getLatestCheckpoint);
            this.Controls.Add(this.HA_setup_hadoop_configs);
            this.Controls.Add(this.Set_replication_path);
            this.Controls.Add(this.Set_replication_Number);
            this.Controls.Add(this.Set_replication);
            this.Controls.Add(this.Format_Namenode);
            this.Controls.Add(this.Rebalance_Cluster_text);
            this.Controls.Add(this.Rebalance_Cluster);
            this.Controls.Add(this.Start_Hadoop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Hadoop;
        private System.Windows.Forms.Button Rebalance_Cluster;
        private System.Windows.Forms.TextBox Rebalance_Cluster_text;
        private System.Windows.Forms.Button Format_Namenode;
        private System.Windows.Forms.Button Set_replication;
        private System.Windows.Forms.TextBox Set_replication_Number;
        private System.Windows.Forms.TextBox Set_replication_path;
        private System.Windows.Forms.Button HA_setup_hadoop_configs;
        private System.Windows.Forms.Button HA_getLatestCheckpoint;
        private System.Windows.Forms.Button HA_startJournalNode;
        private System.Windows.Forms.Button HA_checkNNState;
        private System.Windows.Forms.TextBox HA_checknnstate_serviceID;
        private System.Windows.Forms.Button Set_Active_node;
        private System.Windows.Forms.TextBox set_active_node_text;
        private System.Windows.Forms.Button Set_SingleNode;
        private System.Windows.Forms.TextBox SN_NamenodeIP;
        private System.Windows.Forms.TextBox SN_replication_factor;
        private System.Windows.Forms.Button Slaves;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox JN_combobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ZK_combobox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox add_to_zk_or_jn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox NN_combobox;
        private System.Windows.Forms.TextBox rep_factor_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox jndir_textbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox SetupZK_NN_Combobox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SetupZK_NN_textbox;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox SetupZK_Serverid_text;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SetupZK_MaxClient_textbox;
        private System.Windows.Forms.Label MaxClient;
        private System.Windows.Forms.Button button12;
    }
}

