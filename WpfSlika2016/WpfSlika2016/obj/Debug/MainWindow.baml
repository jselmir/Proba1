   M S B A M L   `   `   `  ����G  CWpfSlika2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfSlika2016WpfSlika2016  5   	       WpfSlika2016.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,localclr-namespace:WpfSlika2016     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��620��6)    � 	Resources 5        WpfSlika2016.PolConverter 	  konv1!  WpfSlika2016.SlikaConverter 	 konv2��%:   &	        &	        5   
   6     5	   
   6   5
      .��5   
   �  � ColumnDefinitions 5   
   �� 5      $
��118* �6   �� 5      $
��399* �6   .+�5   
   �� -   5         ��Name$ Label1��5      $��Id��6    $
��Left=�6-   $��	32,31,0,0q�6H   $	��Top=�6[   �� 5   
   -   5        $ Label2��5      $	��Ime��6!   $
��Left=�6/   $��	32,69,0,0q�6J   $	��Top=�6]    J� RenderTransformOrigin$ 0.447,0.885&�6u   �� 5   
   -   5        $ Label3��5      $��Prezime��6    $
��Left=�62   $��
32,109,0,0q�6M   $	��Top=�6a   �� 5   
   -   5         ��Name$ 	TextBoxId��5      $��2��6%   $
��Left=�69   $��23��6T   $��	97,35,0,0q�6`    �� TextWrapping$
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��120��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ 
TextBoxIme��5      $��2��6&   $
��Left=�6:   $��23��6U   $��	97,73,0,0q�6a   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ TextBoxPrezime��5      $��2��6*   $
��Left=�6>   $��23��6Y   $��
97,113,0,0q�6e   $
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $	��Pol��6   $
��Left=�6    $��
32,163,0,0q�6;   $	��Top=�6O   $��2��6g   $	��185��6{   $��66��6�   .��5      �� .+�5      	� -   5        $��	RadioMale��5       d� 	IsChecked$
 TrueY�6/   $��	Muski pol��6@   $��5q�6T   	� 5      -	   5        $��
RadioFMale��5      $��
Zenski pol��60   $��5q�6E   5      5      �� 5   
   -
   5        $ Label4��5      $��Label��6    $
��Left=�60   $��
43,246,0,0q�6K   $	��Top=�6_   $ 0.605,-0.154&�6w   �� 5   
   -   5        	 ��Name$	 ButtonOdaberi��5      $��2��6(   $��Odaberi��6<   $
��Left=�6N   $��125,249,0,0q�6i   $	��Top=�6~   $��75��6�   6�   �� 5   
   
���   �$��1q�6%   $��2��69   $
��Left=�6M   $	��100��6h   $��
43,312,0,0q�6u   $	��Top=�6�   $	��157��6�   ._�5      �� -   5        
 ��Name$
 image1��5      $��5q�6$   5       �� 5!   
   -   5        $	 
ButtonNovi��5!      $��	Novi unos��6%   $
��Left=�69   $��
43,437,0,0q�6T   $	��Top=�6h   $��75��6�   6�   �� 5"   
   -   5        $	 ButtonUbaci��5"      $��Ubaci��6&   $��1��66   $
��Left=�6F   $��	0,437,0,0q�6a   $	��Top=�6t   $��75��6�   6�   �� 5#   
   -   5        $	 ButtonPromijeni��5#      $��	Promijeni��6*   $��1��6>   $
��Left=�6N   $��
99,437,0,0q�6i   $	��Top=�6}   $��75��6�   6�   �� 5$   
   -   5        $	 ButtonObrisi��5$      $��Obrisi��6'   $��1��68   $
��Left=�6H   $��197,437,0,0q�6c   $	��Top=�6x   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ 	dataGrid1��5'      $��1��5(      $
��Left=�5)      $��
110,31,0,0q�5*      $	��Top=�6'   $	��387��5+      $	��350��6     �� AlternationCount$ 2��5,         AlternatingRowBackground
 ����   CanUserAddRows .     CanUserSortColumns .     AutoGenerateColumns .     SelectionUnit$ FullRow=�51         
IsReadOnly .    Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$	 Ime�  57      $ Prezime��6%   $ 80 66    6A   �� $ Prezime�  58      $	 Pol��6%   $ 80 62    6=   �� $	 Pol� �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  59      $ Fotografija��6)      CellTemplate 5:      �� 5;      .R�5<      �� $��40��6c   ��6$   �� $ Slika�# [ 6c   5=      5?      5B      5D      5E      