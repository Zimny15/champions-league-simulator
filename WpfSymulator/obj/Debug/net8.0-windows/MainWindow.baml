   M S B A M L   `   `   `  ����G  CWpfSymulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfSymulatorWpfSymulator  5   	       WpfSymulator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfSymulator     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � .+�5   
   �� $	��500��6   $h��bhttps://c4.wallpaperflare.com/wallpaper/398/874/541/champions-league-stadium-wallpaper-preview.jpg��6   6�   �� 5   
   -   5         ��Name$ appNameText��5      
��� ���$��50(�6;   $y�Visible=�6I    �� TextAlignment$ Center=�6^   $��170,54,170,237q�6u   �� 5   	   .�6   �� .�6   .�6'   Champions League�� 	SIMULATOR6=   6D   5      9� 5   
   -   5         9�Name$ htpExpander��5      
�������$��How to play?��6;   $��0,1,485,180q�6Q   $��Center=�6f   $	��180��6�   .��5      �� 
����  �
�������$
��Wrap=�6K   ��Play with caution! You can create a new save by entering your name and pressing "Create new profile", choose one created before or play without saving. If you don't like the music, you can always turn it off by pressing a button in the upper left corner. Choose your favourite team and throw yourself into the thrilling Champions League competition. Good luck and have fun!6�  5      r� 5   
   -   5         r�Name$ 
introMusic��5   	    r� Source$ Images\CL_Anthem.mp3?�5   	    r� LoadedBehavior$ Manual=�6'   5      �� 5   
   -   5         ��Name$ musicButton��5      $��50��6@   $��50��6K   $��	0,0,735,0q�6W   $��Center=�6k   $	��Top=�6�   .��5      �� -   5        	 ��Name$	 playingImage��5      $y�Visible=�6*   $[��Uhttps://i.etsystatic.com/38501418/r/il/a13085/4510104766/il_570xN.4510104766_2udh.jpg��6?   6�   5      �� 5   
   -   5        
 ��Name$
 playerProfileChoice��5      $��
690,74,0,0q�6/   $	��110��6C   $��Center=�6O    �� SelectionMode$ Single=�6�   
������� J� Opacity$	 0.4Q�6�   $
��Bold"�6�   �� 5   
   -   5        $ defaultPlayerStart��5      $	��125��6N   $��50��6Z   $��325,125,325,100q�6f   $��20(�6   $
��Bold"�6�   
���������5      �� 5      $
��PLAY��6   $
��Wrap=�6(   5      �� 5    
   -   5        $ startButton��5       $	��125��6@   $��50��6L   $��325,125,325,100q�6X   $��20(�6q   $
��Bold"�6   
���������5!      �� 5"      $
��PLAY��6   $
��Wrap=�6(   5$      �� 5%   
   -	   5         ��Name$ newPlayerProfile��5%      $��Center=�6,   $��
690,15,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��110��6�   $��25��6�   $��12(�6�   $��Center=�6�   $
��Bold"�6�   
�������6�   �� 5&   
   -
   5        $ createButton��5&      $��Create new profile��6'   $��Center=�6D   $��
690,45,0,0q�6a   $	��Top=�6u   $	��110��6�   $��25��6�   
�������$��11(�6�   $
��Bold"�6�   6�   �� 5'   
   -   5        $ 	showScore��5'      $��My Score��6$   $��90��67   $��30��6B   $��325,255,325,100q�6N   $��10(�6g   $
��Bold"�6u   
�������6�   5(      5)      