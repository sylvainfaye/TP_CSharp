namespace MDIParentWPForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            nouveauToolStripMenuItem = new ToolStripMenuItem();
            classeToolStripMenuItem = new ToolStripMenuItem();
            etudiantToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            nouveauToolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip3 = new ContextMenuStrip(components);
            nouveauToolStripMenuItem2 = new ToolStripMenuItem();
            contextMenuStrip4 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            nouveauToolStripMenuItem3 = new ToolStripMenuItem();
            rapportToolStripMenuItem = new ToolStripMenuItem();
            fermerToolStripMenuItem = new ToolStripMenuItem();
            classeToolStripMenuItem1 = new ToolStripMenuItem();
            etudiantToolStripMenuItem1 = new ToolStripMenuItem();
            listeEtudiantToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { nouveauToolStripMenuItem, classeToolStripMenuItem, etudiantToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(156, 100);
            // 
            // nouveauToolStripMenuItem
            // 
            nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            nouveauToolStripMenuItem.Size = new Size(155, 32);
            nouveauToolStripMenuItem.Text = "Nouveau";
            // 
            // classeToolStripMenuItem
            // 
            classeToolStripMenuItem.Name = "classeToolStripMenuItem";
            classeToolStripMenuItem.Size = new Size(155, 32);
            classeToolStripMenuItem.Text = "Classe";
            // 
            // etudiantToolStripMenuItem
            // 
            etudiantToolStripMenuItem.Name = "etudiantToolStripMenuItem";
            etudiantToolStripMenuItem.Size = new Size(155, 32);
            etudiantToolStripMenuItem.Text = "Etudiant";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(24, 24);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { nouveauToolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(156, 36);
            // 
            // nouveauToolStripMenuItem1
            // 
            nouveauToolStripMenuItem1.Name = "nouveauToolStripMenuItem1";
            nouveauToolStripMenuItem1.Size = new Size(155, 32);
            nouveauToolStripMenuItem1.Text = "Nouveau";
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(24, 24);
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { nouveauToolStripMenuItem2 });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(156, 36);
            // 
            // nouveauToolStripMenuItem2
            // 
            nouveauToolStripMenuItem2.Name = "nouveauToolStripMenuItem2";
            nouveauToolStripMenuItem2.Size = new Size(155, 32);
            nouveauToolStripMenuItem2.Text = "Nouveau";
            // 
            // contextMenuStrip4
            // 
            contextMenuStrip4.ImageScalingSize = new Size(24, 24);
            contextMenuStrip4.Name = "contextMenuStrip4";
            contextMenuStrip4.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { nouveauToolStripMenuItem3, rapportToolStripMenuItem, fermerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1425, 33);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // nouveauToolStripMenuItem3
            // 
            nouveauToolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { classeToolStripMenuItem1, etudiantToolStripMenuItem1 });
            nouveauToolStripMenuItem3.Name = "nouveauToolStripMenuItem3";
            nouveauToolStripMenuItem3.Size = new Size(99, 29);
            nouveauToolStripMenuItem3.Text = "Nouveau";
            // 
            // rapportToolStripMenuItem
            // 
            rapportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeEtudiantToolStripMenuItem });
            rapportToolStripMenuItem.Name = "rapportToolStripMenuItem";
            rapportToolStripMenuItem.Size = new Size(93, 29);
            rapportToolStripMenuItem.Text = "Rapport";
            // 
            // fermerToolStripMenuItem
            // 
            fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            fermerToolStripMenuItem.Size = new Size(83, 29);
            fermerToolStripMenuItem.Text = "Fermer";
            // 
            // classeToolStripMenuItem1
            // 
            classeToolStripMenuItem1.Name = "classeToolStripMenuItem1";
            classeToolStripMenuItem1.Size = new Size(270, 34);
            classeToolStripMenuItem1.Text = "Classe";
            classeToolStripMenuItem1.Click += classeToolStripMenuItem1_Click;
            // 
            // etudiantToolStripMenuItem1
            // 
            etudiantToolStripMenuItem1.Name = "etudiantToolStripMenuItem1";
            etudiantToolStripMenuItem1.Size = new Size(270, 34);
            etudiantToolStripMenuItem1.Text = "Etudiant";
            // 
            // listeEtudiantToolStripMenuItem
            // 
            listeEtudiantToolStripMenuItem.Name = "listeEtudiantToolStripMenuItem";
            listeEtudiantToolStripMenuItem.Size = new Size(270, 34);
            listeEtudiantToolStripMenuItem.Text = "Liste Etudiant";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1425, 802);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip3.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem nouveauToolStripMenuItem;
        private ToolStripMenuItem classeToolStripMenuItem;
        private ToolStripMenuItem etudiantToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem nouveauToolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem nouveauToolStripMenuItem2;
        private ContextMenuStrip contextMenuStrip4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem nouveauToolStripMenuItem3;
        private ToolStripMenuItem classeToolStripMenuItem1;
        private ToolStripMenuItem etudiantToolStripMenuItem1;
        private ToolStripMenuItem rapportToolStripMenuItem;
        private ToolStripMenuItem listeEtudiantToolStripMenuItem;
        private ToolStripMenuItem fermerToolStripMenuItem;
    }
}
