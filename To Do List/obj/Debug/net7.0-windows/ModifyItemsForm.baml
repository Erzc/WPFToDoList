   M S B A M L   `   `   `  ����E  ATo Do List, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:To_Do_List
To_Do_List  5   	        To_Do_List.ModifyItemsForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:To_Do_List     5   	     � Title$  ModifyItemsForm��5   	   $��600         ��6!   $	��800��5	      .��5
      � .+�5   
   �� $��Modify your To Do item:��6   $��Center=�62   $��0,10,0,0q�6O   $	��Top=�6a   $��22(�6y   $
��Bold"�6�   �� 5   
   -   5         ��Name$ descriptionTb��5      $
��Left=�6)    �� TextWrapping$
 Wrap=�6D   $	��Top=�6X   $	��549��6p   $	��407��6|   $��
28,110,0,0q�6�   �� 5   
   -   5        $ titleTb��5      $
��Left=�6#   $��	28,54,0,0q�6>   $
 Wrap=�6Q   $	��Top=�6e   $	��549��6}   $��25��6�   $��18(�6�   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ dueDateCalendar��5      $
��Left=�6,   $��593,330,0,0q�6G   $	��Top=�6\   6t   �� 5   
   -   5         ��Name$ submitButton��5      $��Submit��6'   $
��Left=�68   $��254,522,0,0q�6S   $	��Top=�6h   $��91��6�   $��35��6�   $��16(�6�   6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��400,522,0,0q�6S   $	��Top=�6h   $��91��6�   $��35��6�   $��16(�6�   6�   �� 5   
   $��Select deadline:��6   $
��Left=�6+   $��629,310,0,0q�6F   $	��Top=�6[   $��14(�6s   �� 5   
   -   5        $ costTb��5      $
��Left=�6"   $��678,109,0,0q�6=   $
 Wrap=�6R   $	��Top=�6f   $��89��6~   $��25��6�   $��18(�6�   6�   �� 5   
   $��Cost (if any):��6   $
��Left=�6)   $��593,107,0,0q�6D   $	��Top=�6Y   $��14(�6q   �� 5   
   $��Title:��6   $
��Left=�6!   $��	28,29,0,0q�6<   $	��Top=�6O   $��14(�6g   $��62��6u   �� 5   
   $��Example: 55.55��6   $
��Left=�6)   $��679,132,0,0q�6D   
�������$	��Top=�6o   $��12(�6�   $��92��6�   �� 5   
   $��Description:��6   $
��Left=�6'   $��	28,84,0,0q�6B   $	��Top=�6U   $��14(�6m   $��94��6{   �� 5   
   -   5         ��Name$ costTypeCob��5      $
��Left=�6(   $��670,190,0,0q�6C   $	��Top=�6X   $	��101��6p    �� 
IsReadOnly$
 True��6|   .@�5      �� $��Daily��6   �� 5      $��Monthly��6   �� 5      $��Yearly��6   �� 5      $��One Time��6   5      �� 5   
   $��     Cost
Frequency:��6   $
��Left=�68   $��593,178,0,0q�6S   $	��Top=�6h   $��14(�6�   5      5       