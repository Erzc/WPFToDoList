   M S B A M L   `   `   `  ����E  ATo Do List, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:To_Do_List
To_Do_List  5   	       To_Do_List.MainListForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:To_Do_List     5   	     � Title$  MainListForm��5   	   $��700                  ��6   $	��800��5
      .��5      � .+�5   
   �� -   5         ��Name$ 
mainformLb��5      $��33,139,144,25q�6Q   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 5q�6/   �� 5       � ��$	 125��6/   �� 5       � ��$	 500��6.   5      5      �� 5   
   -   5         ��Name$ 	addButton��5      $	��Add��6$   $
��Left=�62   $��666,481,0,0q�6M   $	��Top=�6b   $��92��6z   $��34��6�   $��16(�6�   �� 5   
   -   5        $ deleteButton��5      $��Delete��6'   $
��Left=�68   $��666,584,0,0q�6S   $	��Top=�6h   $��92��6�   $��35��6�   $��16(�6�   �� 5   
   $��To Do List Application��6   $��Center=�61   $��0,5,0,0q�6N   $	��Top=�6_   $	��250��6w   $��22(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 
instructTb��5      $
��Left=�6&   $��
169,44,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $����To add an item, click the Add button, complete the form, and click Submit.
To edit, select an item in the list, and click the Edit button.
To delete, select an item in the list and click the Delete button.��6i   $	��Top=�6F  $	��436��6^  $��57��6j  �� 5   
   -   5         ��Name$ instructLbl��5      $��Instructions:��6%   $
��Left=�6=   $��	78,56,0,0q�6X   $	��Top=�6k   $��86��6�   $��14(�6�   �� 5   
   -   5        $ 
editButton��5      $
��Edit��6%   $
��Left=�64   $��666,533,0,0q�6O   $	��Top=�6d   $��92��6|   $��35��6�   $��16(�6�   �� 5    
   -   5        $ 
saveButton��5       $��	Save List��6%   $
��Left=�69   $��
657,38,0,0q�6T   $	��Top=�6h   $��91��6�   $��35��6�   $��16(�6�   �� 5!   
   -   5        $ nameTb��5!      $
��Left=�6"   $��114,106,0,0q�6=   $
 Wrap=�6R   $	��Top=�6f   $	��282��6~   $��28��6�   $��18(�6�   $��Italic$�6�   �� 5"   
   -	   5        $ 
openButton��5"      $��	Open List��6%   $
��Left=�69   $��
657,82,0,0q�6T   $	��Top=�6h   $��91��6�   $��35��6�   $��16(�6�   �� 5#   
   -
   5        $ nameLbl��5#      $��
Your Name:��6!   $
��Left=�66   $��
33,105,0,0q�6Q   $	��Top=�6e   $��81��6}   $��14(�6�   �� 5$   
   $%��  Total Costs
(for all items):��6   $
��Left=�6B   $��657,204,0,0q�6]   $	��Top=�6r   $	��113��6�   $��76��6�   $��18(�6�   �� 5%   
   -   5        $ totalsTb��5%      $
��Left=�6$   $��662,260,0,0q�6?   $
 Wrap=�6T   $��$0.00��6h   $	��Top=�6u   $	��102��6�   $��30��6�   $��16(�6�   �� 5&   
   $�� Item Count��6   $
��Left=�6&   $��656,341,0,0q�6A   $	��Top=�6V   $	��134��6n   $��34��6z   $��18(�6�   �� 5'   
   -   5        $ totalsCountTb��5'      $
��Left=�6)   $��676,375,0,0q�6D   $
 Wrap=�6Y   $��0��6m   $	��Top=�6v   $��74��6�   $��30��6�   $��16(�6�   5)      5+      