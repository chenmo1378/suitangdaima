   M S B A M L   `   `   `  ����  	HRMSys.UI,    &HRMSys.UI.SystemMgr.OperationLogWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  OperationLogWindow��5   	   $	��800��6$   $	��600��61   .��5      � .+�5   
   ]� .+�5      �� $	��100��6   $��搜索条件��6$   $	��Top=�62   .��5      � .+�5	      �� -   5        $��cbSearchByOperator��5	   e   $��	操作员��6   $��16��6-   $
��Left=�69   $��6,6,0,0q�6T   $	��Top=�6   �� 5
      -   5        $��cbSearchByMakeDate��5
   h   $��操作日期��6   $��16��6.   $
��Left=�6:   $��	198,6,0,0q�6U   $	��Top=�6�   �� 5      -   5        $��cbSearchByAction��5   h   $��操作描述��6   $��16��6.   $
��Left=�6:   $��	11,45,0,0q�6U   $	��Top=�6�   �� 5      -   5        $��cmbOperator��5   �    �� DisplayMemberPath$ UserName��6    �� SelectedValuePath$ Id��6<   $��23��6S   $
��Left=�6_   $��72,6,0,0q�6z   $	��Top=�6�   $	��106��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpBeginDate��5   [   $��25��6!   $
��Left=�6-   $��	272,4,0,0q�6H   $	��Top=�6n   $	��115��6�     5      -   5        $��	dpEndDate��5   [   $��25��6!   $
��Left=�6-   $��	445,4,0,0q�6H   $	��Top=�6l   $	��115��6�   �� 5      -   5        $��
textBlock1��5   Z   $��23��6    $
��Left=�6,   $��	398,5,0,0q�6G   $	��到��6l   $	��Top=�6u   �� 5      -	   5        $��txtAcionDesc��5   X   $��23��6   $
��Left=�6*   $��	95,38,0,0q�6E   $	��Top=�6l   $	��120��6�   �� 5      -
   5        $��	btnSearch��5   e   $��搜索��6   $��23��6*   $
��Left=�66   $��
264,38,0,0q�6Q   $	��Top=�6v   $��75��6�   6�   5      5      &   System.Windows.Controls.DataGrid  5      -   5        $��datagrid��5   ,   $	��Top=�6      
IsReadOnly .    AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	操作员��6-      SelectedValuePath$ Id��5   -      DisplayMemberPath$ UserName��5   -   -   5        colOperator��	   SelectedValueBinding	 5   :   �� *
OperatorId+5   a   0  *System.Windows.Controls.DataGridTextColumn  5      $ 日期��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *
MakeDate+6T     5      $ 说明��6)   
 65   �� *
ActionDesc+6V   5      5      5      5      