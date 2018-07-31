namespace keizaBanner
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
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.yeetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.ContextMenuStrip = this.contextMenuStrip1;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(954, 37);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "~good morning~";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yeetToolStripMenuItem
            // 
            this.yeetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yoteToolStripMenuItem});
            this.yeetToolStripMenuItem.Name = "yeetToolStripMenuItem";
            this.yeetToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.yeetToolStripMenuItem.Text = "yeet";
            // 
            // yoteToolStripMenuItem
            // 
            this.yoteToolStripMenuItem.Name = "yoteToolStripMenuItem";
            this.yoteToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.yoteToolStripMenuItem.Text = "yote";
            // 
            // weetToolStripMenuItem
            // 
            this.weetToolStripMenuItem.Name = "weetToolStripMenuItem";
            this.weetToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.weetToolStripMenuItem.Text = "weet";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeetToolStripMenuItem,
            this.weetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 48);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(954, 37);
            this.Controls.Add(this.lblMessage);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "keizaBanner 0.3A  -  eriPoison";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ToolStripMenuItem yeetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;        
    }
}

