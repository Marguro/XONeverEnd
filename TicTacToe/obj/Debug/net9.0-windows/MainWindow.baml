   M S B A M L   `   `   `  ����  TicTacToeWPF    TicTacToeWPF.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  XONeverDraw��5   	   $	��450��6   $	��800��6*   $��Inter)�5   	      BackgroundColor#��[  5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5        RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%  &	       �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $��1q�5   !   $ 10��5   !   # z��5   !   ._�5      �� #��z��6/   #��z��5   /   5      5      5      5      5      .��5      (� .��5   
   � 	 � RowDefinitions	 5      �� 5       $
��Auto �6    �� 5!      $��* �6    .+�5$      �� -   5        
 ��Name$
 	TurnPanel��5$       �� Orientation$ 
Horizontal=�5%      $��Center=�5&      $y�Hidden=�5'      .+�5(      �� $��54(�6   $��Player:��5)      $
��Bold"�5*      �� 5+      -   5         ��Name$ PlayerImage��5+      $��Assets/X15.png��5,      $��75��5-      5.      �� 50      -   5         ��Name$ 
GameCanvas��50      $��1��51      $	��300��52      $	��300��53      $��20q�54      $y�Hidden=�55      .+�57      A� -   5         A�Name$ GameGrid��57      $	��300��58      $	��300��59       A� Rows$ 3��5:       A� Columns$ 3��5;      ��5=      �� 5>       �� ImageSource$ Assets/Grid.png��6%   5@      �� 5A      -   5         ��Name$
 Line��5A        	LineColor#��[ 5B      $��10��5C       �� StrokeStartLineCap$ Round=�5D       �� StrokeEndLineCap$ Round=�5E      $y�Hidden=�5F      5G      � 5I      -   5         �Name$ 	EndScreen��5I      $��2��5J      #��[  5K      $y�Hidden=�5L      .+�5M      �� $ Vertical=�6   $��Center=�5N      .+�5O      �� $ 
Horizontal=�6!   $��Center=�5P   !   .+�5Q      �� -   5         ��Name$ 
ResultText��5Q   $   $��54(�5R   $   $��Winner: ��5S   $   $��0,0,0,15q�5T   $   $
��Bold"�5U   $   �� 5V      -   5        $ WinnerImage��5V       $��60��5W       $��	10,0,0,10q�5X       $��Assets/X15.png��5Y       5Z      �� 5\      -	   5        $��
Play Again��5\        ButtonColor#��[ 5]      $��34(�5^      $	��200��5_      $��60��5`      $��0,20,0,0q�5a      $��0,0,0,5q�5b      
�������#��[ 5e      $��Center=�5f      $��Center=�5g      $
��Bold"�5h      5i      5j      � 5l      -
   5        $ StartScreen��5l      $��2��5m      #��[  5n      $y�Visible=�5o      .+�5p      �� $ Vertical=�6   $��Center=�5q      .+�5r      �� $ 
Horizontal=�6!   $��Center=�5s   !   .+�5t      �� $��54(�6$   $��XO NeverDraw��5u   $   $��0,0,0,15q�5v   $   $
��Bold"�5w   $   5x      �� 5z      -   5        $��Start��5z      #��[ 5{      $��34(�5|      $	��150��5}      $��60��5~      $��0,20,0,0q�5      $��0,0,0,5q�5�      
�������#��[ 5�      $��Center=�5�      $��Center=�5�      $
��Bold"�5�      5�      5�      5�      5�      5�      