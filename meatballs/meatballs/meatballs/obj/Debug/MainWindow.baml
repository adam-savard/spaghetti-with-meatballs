   M S B A M L   `   `   `  ����D  @meatballs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:meatballs	meatballs  5   	       meatballs.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:meatballs     5   	     � Title$   Meatballs De-Spaghettifier��5   	   $��351.557��6,   $��439.403��6=    � WindowStartupLocation$ CenterScreen=�6M    � Icon$ img/spaghetti.png��6r   .��5	      � $��0,0,2,-2q�6    � ColumnDefinitions 5
   
   �� 5      $
��307* �6   �� 5      $	��89* �6   .+�5   
   �� -   5         ��Name$ txtTest��5      $
��Test��6!   $
��Left=�60   $	��Top=�6K   $��142,176,0,0q�6c   $	��162��6x   �� 5   
   -   5         ��Name$ btnCreateProject��5      $��New Project��6+   $
��Left=�6A   $	��Top=�6\   $	��162��6t   $��
142,76,0,0q�6�   6�   �� 5   
   -   5        $ btnNewAuthor��5      $��
New Author��6'   $
��Left=�6<   $	��Top=�6W   $	��162��6o   $��
142,51,0,0q�6{   6�   �� 5   
   -   5        $ 
btnNewFile��5      $��New File��6%   $
��Left=�68   $	��Top=�6S   $	��162��6k   $��142,101,0,0q�6w   �� 5   
   -   5        $ btnFunctionEntry��5      $��Function Entry��6+   $
��Left=�6D   $	��Top=�6_   $	��162��6w   $��142,126,0,0q�6�   ]� 5   
   $��	0,0,0,393q�6   .+�5      `� $	��Top=�6   $��
0,0,-164,0q�6/   .�5      c� 5      5      �� 5   
   -   5        $ btnFunctionScan��5      $��Scan For Functions...��6*   $
��Left=�6J   $	��Top=�6e   $	��162��6}   $��142,151,0,0q�6�   6�   �� 5   
   -   5        $ btnTest��5      $#��Test Writing/Calling Function��6"   $
��Left=�6J   $	��Top=�6e   $	��162��6}   $��142,207,0,0q�6�   6�   5      5      