   M S B A M L   `   `   `  ����G  CWpfSymulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfSymulatorWpfSymulator  5   	       WpfSymulator.SecondWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfSymulator     5   	     � Title$  SecondWindow��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67    � 	Resources 5	         TransparentButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName��%�  &	        �� 5
   
   " ��6/   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   
������ ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   �� $ border��6)    � ��
 ��ح�6S   5      P� 5      	 � {�$
 False��6;   . �5   "   �� $ border��6)    � ��
 ���� 6S   5      5      5      5      5      .��5       � .+�5!   
   �� $	��500��6   $h��bhttps://c4.wallpaperflare.com/wallpaper/398/874/541/champions-league-stadium-wallpaper-preview.jpg��6   6�   �� 5"   
   -   5        $��wyborDruzyny��5"      $��30(�6(   $��Italic$�66   $��Heavy"�6I   $��Center=�6\   $��30q�6z   
������ 
��� ���CHOOSE YOUR TEAM6�   �� 5#   
   $
��Left=�6   $��
96,140,0,0q�60   $	��Top=�6D   .+�5$      �� -   5        $��
RealMadrit��5$   .   $��80��6@   #��[  6K   .��5%      �� $��Images\real_logo.png��6   $��80��66   6C   5&      �� 5'      $��Real Madrit��6    �� TextAlignment$ Center=�6+   
��� ���$
��Bold"�6T   $��15(�6f   5(      �� 5)   
   $
��Left=�6   $��272,140,0,0q�60   $	��Top=�6E   .+�5*      �� -   5        $��FCBarcelona��5*   0   $��80��6C   #��[  6N   .��5+      �� $��Images\barcelona_logo.png��6   $��80��6;   6H   5,      �� 5-      $��FC Barcelona��6   $ Center=�6,   
��� ���$
��Bold"�6U   $��15(�6g   5.      �� 5/   
   $
��Left=�6   $��434,140,0,0q�60   $	��Top=�6E   .+�50      �� -   5        $��ManchesterCity��50   2   $��80��6H   #��[  6S   .��51      �� $��Images\city_logo.png��6   $��80��66   6C   52      �� 53      $��Manchester City��6   $ Center=�6/   
��� ���$
��Bold"�6X   $��15(�6j   54      �� 55   
   $
��Left=�6   $��604,140,0,0q�60   $	��Top=�6E   .+�56      �� -   5        $��ManchesterUnited��56   4   $��80��6L   #��[  6W   .��57      �� $��Images\united_logo.png��6   $��80��68   $��80��6C   58      59      �� 5:      $��Manchester United��6   $ Center=�61   
��� ���$
��Bold"�6Z   $��15(�6l   5;      �� 5>   
   $
��Left=�6   $��
96,300,0,0q�60   $	��Top=�6D   .+�5?      �� -   5        $	��PSG��5?   '   $��80��62   #��[  6=   .��5@      �� $��Images\psg_logo.png��6   $��80��65   6B   5A      �� 5B      $	��PSG��6   $ Center=�6#   
��� ���$
��Bold"�6L   $��15(�6^   5C      �� 5D   
   $
��Left=�6   $��272,300,0,0q�60   $	��Top=�6E   .+�5E      �� -   5        $��	Liverpool��5E   -   $��80��6>   $��80��6I   #��[  6U   .��5F      �� $��Images\liverpool_logo.png��6   $��80��6;   $��80��6F   6T   5G      �� 5H      $��	Liverpool��6   $ Center=�6)   
��� ���$
��Bold"�6R   $��15(�6d   5I      �� 5J   
   $
��Left=�6   $��448,300,0,0q�60   $	��Top=�6E   .+�5K      �� -   5        $��FCBayern��5K   ,   $��80��6<   #��[  6G   .��5L      �� $��Images\bayern_logo.png��6   $��80��68   $��80��6C   6Q   5M      �� 5N      $��	FC Bayern��6   $ Center=�6)   
��� ���$
��Bold"�6R   $��15(�6d   5O      �� 5P   
   $
��Left=�6   $��624,300,0,0q�60   $	��Top=�6E   .+�5Q      �� -	   5        $��WislaKrakow��5Q   /   $��80��6B   $��80��6M   #��[  6Z   .��5R      �� $��Images\wisla_logo.png��6   $��80��67   $��80��6B   6P   5S      �� 5T      $��Wisla Krakow��6   $ Center=�6,   
��� ���$
��Bold"�6U   $��15(�6g   5U      r� 5V   
   -
   5         r�Name$ topMusic��5V       r� Source$ Images\PercheTiAmo.mp3?�6)    r� LoadedBehavior$ Manual=�6I   6c   r� 5W   
   -   5        $ 
wislaMusic��5W      $ Images\WislaSong.mp3?�6+   $ Manual=�6I   6c   5X      5Y      