namespace OSRS_Ping {
    partial class OSRSWorldPing {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnPing = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.worldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worldLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worldPing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(188, 4);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(88, 23);
            this.btnPing.TabIndex = 0;
            this.btnPing.Text = "Get World Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.worldID,
            this.numPlayers,
            this.worldLocation,
            this.worldType,
            this.worldPing});
            this.dataGridView.Location = new System.Drawing.Point(2, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(562, 280);
            this.dataGridView.TabIndex = 3;
            // 
            // worldID
            // 
            this.worldID.HeaderText = "World";
            this.worldID.Name = "worldID";
            this.worldID.ReadOnly = true;
            // 
            // numPlayers
            // 
            this.numPlayers.HeaderText = "Players";
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.ReadOnly = true;
            // 
            // worldLocation
            // 
            this.worldLocation.HeaderText = "Location";
            this.worldLocation.Name = "worldLocation";
            this.worldLocation.ReadOnly = true;
            // 
            // worldType
            // 
            this.worldType.HeaderText = "Type";
            this.worldType.Name = "worldType";
            this.worldType.ReadOnly = true;
            // 
            // worldPing
            // 
            this.worldPing.HeaderText = "Ping (ms)";
            this.worldPing.Name = "worldPing";
            this.worldPing.ReadOnly = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(282, 9);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 4;
            // 
            // OSRSWorldPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 314);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnPing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "OSRSWorldPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSRS World Ping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OSRSWorldPing_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn worldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn numPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn worldLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn worldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn worldPing;
    }
}

