namespace ImageProcessingAlgorithms
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRGBHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenMasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMask3x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.directionDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.windowsMenu,
            this.lab1ToolStripMenuItem,
            this.lab2ToolStripMenuItem,
            this.lab3ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(1218, 42);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(62, 34);
            this.fileMenu.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(257, 40);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(254, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(257, 40);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(257, 40);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(254, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(257, 40);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(257, 40);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.toolStripSeparator7});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(66, 34);
            this.editMenu.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(252, 40);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(252, 40);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(249, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(249, 6);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(116, 34);
            this.windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(265, 40);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(265, 40);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(265, 40);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(265, 40);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(265, 40);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // lab1ToolStripMenuItem
            // 
            this.lab1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHistogramToolStripMenuItem,
            this.showRGBHistogramToolStripMenuItem,
            this.makeGrayscaleToolStripMenuItem});
            this.lab1ToolStripMenuItem.Name = "lab1ToolStripMenuItem";
            this.lab1ToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            this.lab1ToolStripMenuItem.Text = "Lab1";
            // 
            // showHistogramToolStripMenuItem
            // 
            this.showHistogramToolStripMenuItem.Name = "showHistogramToolStripMenuItem";
            this.showHistogramToolStripMenuItem.Size = new System.Drawing.Size(328, 40);
            this.showHistogramToolStripMenuItem.Text = "Show Histogram";
            this.showHistogramToolStripMenuItem.Click += new System.EventHandler(this.showHistogramToolStripMenuItem_Click);
            // 
            // showRGBHistogramToolStripMenuItem
            // 
            this.showRGBHistogramToolStripMenuItem.Name = "showRGBHistogramToolStripMenuItem";
            this.showRGBHistogramToolStripMenuItem.Size = new System.Drawing.Size(328, 40);
            this.showRGBHistogramToolStripMenuItem.Text = "Show RGB Histogram";
            this.showRGBHistogramToolStripMenuItem.Click += new System.EventHandler(this.showRGBHistogramToolStripMenuItem_Click);
            // 
            // makeGrayscaleToolStripMenuItem
            // 
            this.makeGrayscaleToolStripMenuItem.Name = "makeGrayscaleToolStripMenuItem";
            this.makeGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(328, 40);
            this.makeGrayscaleToolStripMenuItem.Text = "Make Grayscale";
            this.makeGrayscaleToolStripMenuItem.Click += new System.EventHandler(this.makeGrayscaleToolStripMenuItem_Click);
            // 
            // lab2ToolStripMenuItem
            // 
            this.lab2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchHistogramToolStripMenuItem,
            this.adjustToolStripMenuItem,
            this.equalizeToolStripMenuItem1,
            this.thresholdToolStripMenuItem,
            this.thresholdGrayscaleToolStripMenuItem,
            this.posterizeToolStripMenuItem,
            this.inverseToolStripMenuItem});
            this.lab2ToolStripMenuItem.Name = "lab2ToolStripMenuItem";
            this.lab2ToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            this.lab2ToolStripMenuItem.Text = "Lab2";
            // 
            // stretchHistogramToolStripMenuItem
            // 
            this.stretchHistogramToolStripMenuItem.Name = "stretchHistogramToolStripMenuItem";
            this.stretchHistogramToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.stretchHistogramToolStripMenuItem.Text = "Stretch Histogram";
            this.stretchHistogramToolStripMenuItem.Click += new System.EventHandler(this.stretchHistogramToolStripMenuItem_Click);
            // 
            // adjustToolStripMenuItem
            // 
            this.adjustToolStripMenuItem.Name = "adjustToolStripMenuItem";
            this.adjustToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.adjustToolStripMenuItem.Text = "Adjust Histogram";
            this.adjustToolStripMenuItem.Click += new System.EventHandler(this.adjustToolStripMenuItem_Click);
            // 
            // equalizeToolStripMenuItem1
            // 
            this.equalizeToolStripMenuItem1.Name = "equalizeToolStripMenuItem1";
            this.equalizeToolStripMenuItem1.Size = new System.Drawing.Size(316, 40);
            this.equalizeToolStripMenuItem1.Text = "Equalize Histogram";
            this.equalizeToolStripMenuItem1.Click += new System.EventHandler(this.equalizeToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.thresholdToolStripMenuItem.Text = "Threshold Binarize";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // thresholdGrayscaleToolStripMenuItem
            // 
            this.thresholdGrayscaleToolStripMenuItem.Name = "thresholdGrayscaleToolStripMenuItem";
            this.thresholdGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.thresholdGrayscaleToolStripMenuItem.Text = "Threshold Grayscale";
            this.thresholdGrayscaleToolStripMenuItem.Click += new System.EventHandler(this.thresholdGrayscaleToolStripMenuItem_Click);
            // 
            // posterizeToolStripMenuItem
            // 
            this.posterizeToolStripMenuItem.Name = "posterizeToolStripMenuItem";
            this.posterizeToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.posterizeToolStripMenuItem.Text = "Posterize";
            this.posterizeToolStripMenuItem.Click += new System.EventHandler(this.posterizeToolStripMenuItem_Click);
            // 
            // inverseToolStripMenuItem
            // 
            this.inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            this.inverseToolStripMenuItem.Size = new System.Drawing.Size(316, 40);
            this.inverseToolStripMenuItem.Text = "Inverse";
            this.inverseToolStripMenuItem.Click += new System.EventHandler(this.inverseToolStripMenuItem_Click);
            // 
            // lab3ToolStripMenuItem
            // 
            this.lab3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointOperationsToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.operatorsToolStripMenuItem,
            this.medianFiltrationToolStripMenuItem,
            this.sharpenMasksToolStripMenuItem,
            this.customMask3x3ToolStripMenuItem,
            this.directionDetectionToolStripMenuItem});
            this.lab3ToolStripMenuItem.Name = "lab3ToolStripMenuItem";
            this.lab3ToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            this.lab3ToolStripMenuItem.Text = "Lab3";
            // 
            // pointOperationsToolStripMenuItem
            // 
            this.pointOperationsToolStripMenuItem.Name = "pointOperationsToolStripMenuItem";
            this.pointOperationsToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.pointOperationsToolStripMenuItem.Text = "Point Operations";
            this.pointOperationsToolStripMenuItem.Click += new System.EventHandler(this.pointOperationsToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem1,
            this.gaussianBlurToolStripMenuItem1});
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.blurToolStripMenuItem.Text = "Linear Softening";
            // 
            // operatorsToolStripMenuItem
            // 
            this.operatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelToolStripMenuItem,
            this.laplaceToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.prewittToolStripMenuItem});
            this.operatorsToolStripMenuItem.Name = "operatorsToolStripMenuItem";
            this.operatorsToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.operatorsToolStripMenuItem.Text = "Edge Detection";
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.sobelToolStripMenuItem.Text = "Sobel";
            // 
            // laplaceToolStripMenuItem
            // 
            this.laplaceToolStripMenuItem.Name = "laplaceToolStripMenuItem";
            this.laplaceToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.laplaceToolStripMenuItem.Text = "Laplace";
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.cannyToolStripMenuItem.Text = "Canny";
            // 
            // sharpenMasksToolStripMenuItem
            // 
            this.sharpenMasksToolStripMenuItem.Name = "sharpenMasksToolStripMenuItem";
            this.sharpenMasksToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.sharpenMasksToolStripMenuItem.Text = "Sharpen";
            this.sharpenMasksToolStripMenuItem.Click += new System.EventHandler(this.sharpenMasksToolStripMenuItem_Click);
            // 
            // customMask3x3ToolStripMenuItem
            // 
            this.customMask3x3ToolStripMenuItem.Name = "customMask3x3ToolStripMenuItem";
            this.customMask3x3ToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.customMask3x3ToolStripMenuItem.Text = "Custom mask 3x3";
            this.customMask3x3ToolStripMenuItem.Click += new System.EventHandler(this.customMask3x3ToolStripMenuItem_Click);
            // 
            // medianFiltrationToolStripMenuItem
            // 
            this.medianFiltrationToolStripMenuItem.Name = "medianFiltrationToolStripMenuItem";
            this.medianFiltrationToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.medianFiltrationToolStripMenuItem.Text = "Median Filtration";
            this.medianFiltrationToolStripMenuItem.Click += new System.EventHandler(this.medianFiltrationToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 42);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip.Size = new System.Drawing.Size(1218, 38);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(40, 32);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(40, 32);
            this.saveToolStripButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 718);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip.Size = new System.Drawing.Size(1218, 39);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(69, 30);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(206, 30);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem1,
            this.horizontalToolStripMenuItem1});
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.prewittToolStripMenuItem.Text = "Prewitt operator";
            // 
            // verticalToolStripMenuItem1
            // 
            this.verticalToolStripMenuItem1.Name = "verticalToolStripMenuItem1";
            this.verticalToolStripMenuItem1.Size = new System.Drawing.Size(315, 40);
            this.verticalToolStripMenuItem1.Text = "Vertical";
            this.verticalToolStripMenuItem1.Click += new System.EventHandler(this.verticalToolStripMenuItem1_Click);
            // 
            // horizontalToolStripMenuItem1
            // 
            this.horizontalToolStripMenuItem1.Name = "horizontalToolStripMenuItem1";
            this.horizontalToolStripMenuItem1.Size = new System.Drawing.Size(315, 40);
            this.horizontalToolStripMenuItem1.Text = "Horizontal";
            this.horizontalToolStripMenuItem1.Click += new System.EventHandler(this.horizontalToolStripMenuItem1_Click);
            // 
            // blurToolStripMenuItem1
            // 
            this.blurToolStripMenuItem1.Name = "blurToolStripMenuItem1";
            this.blurToolStripMenuItem1.Size = new System.Drawing.Size(315, 40);
            this.blurToolStripMenuItem1.Text = "Blur";
            this.blurToolStripMenuItem1.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem1
            // 
            this.gaussianBlurToolStripMenuItem1.Name = "gaussianBlurToolStripMenuItem1";
            this.gaussianBlurToolStripMenuItem1.Size = new System.Drawing.Size(315, 40);
            this.gaussianBlurToolStripMenuItem1.Text = "Gaussian Blur";
            this.gaussianBlurToolStripMenuItem1.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // directionDetectionToolStripMenuItem
            // 
            this.directionDetectionToolStripMenuItem.Name = "directionDetectionToolStripMenuItem";
            this.directionDetectionToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.directionDetectionToolStripMenuItem.Text = "Direction Detection";
            this.directionDetectionToolStripMenuItem.Click += new System.EventHandler(this.directionDetectionToolStripMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 757);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem lab1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showRGBHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdGrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenMasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customMask3x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeGrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem directionDetectionToolStripMenuItem;
    }
}



