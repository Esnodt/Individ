   M S B A M L   `   `   `  ����B  >individ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:individ.Pagesindivid.Pages  5           individ.Pages.MoreInfoPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:individ.Pages     5      -   5          N� Title$  MoreInfoPage��5	      .��5      � .+�5   
   � .+�5      �� .+�5      �� $��/Fon/fonimage.jpg��6   65   5      � 5       � RowDefinitions 5      �� 5      $��50 �6$   62   �� 5      $	��450 �6$   63   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$
 Back��5       $��
Назад��5      
���  ��5"      �� 5$      -   5        $ 
ButtonEdit��5%      
���   �$ ��Редактировать��5'      5(      5*      &   System.Windows.Controls.DataGrid  50      -   5          Name$ DataGridMoreInfo��50   (   $��1��6      
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6T      AutoGenerateColumns .     Columns 52      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер работы��56      
   Width$
 * 57   A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *Work.NumberWork+58        5;      $#	 Название работы��5<      $
 * 5=   ?    6   �� *Work.NameWork+5>        5@      $#	 Номер работника��5A      $
 * 5B   I    6   �� *Employee.NumberEmployee+5C        5E      $	 ФИО Работника��5F      $
 * 5G   C    6   �� *Employee.FullName+5H        5J      $	 Профессия��5K      $
 * 5L   C    6   �� *Employee.Position+5M        5O      $#	 Дата завершения��5P      $
 * 5Q   I    6   �� *WorkInfo.DateOfComplite+5R        5T      $:	 4Планируемая дата завершения��5U      $
 * 5V   P    6   �� * WorkInfo.PlannedDateFoComplite+5W        5Y      $	 Трудоемкость��5Z      $
 * 5[   H    6   �� *WorkInfo.Laboriousness+5\        5^      $ 	 Завершенность��5_      $
 * 5`   D    6   �� *WorkInfo.Readiness+5a      5e      5g      5i      5j      5k      