   M S B A M L   `   `   `  ����   XONeverDraw    TicTacToeWPF.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  XONeverDraw��$	��450��$	��800��$��Inter)�   BackgroundColor#��[   � WindowStartupLocation$ CenterScreen=� � 	Resources   RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%v   &	       �� " ��.���  � �� �� " ��.R��� #��z��#��z��$��1q�$ 10��# z��._��� #��z��#��z��.��(� .��� 	 � RowDefinitions	 �� $
��Auto ��� $��* �.+��� -   
 ��Name$
 	TurnPanel�� �� Orientation$ 
Horizontal=�$��Center=�$y�Hidden=�.+��� $��54(�$��Player:��$
��Bold"��� -    ��Name$ PlayerImage��$��Assets/X15.png��$��75���� -    ��Name$ 
GameCanvas��$��1��$	��300��$	��300��$��20q�$y�Hidden=�.+�A� -    A�Name$ GameGrid��$	��300��$	��300�� A� Rows$ 3�� A� Columns$ 3������  �� ImageSource$ Assets/Grid.png���� -    ��Name$
 Line��  	LineColor#��[ $��10�� �� StrokeStartLineCap$ Round=� �� StrokeEndLineCap$ Round=�$y�Hidden=�� -    �Name$ 	EndScreen��$��2��#��[  $y�Hidden=�.+��� $ Vertical=�$��Center=�.+��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ 
ResultText��$��54(�$��Winner: ��$��0,0,0,15q�$
��Bold"��� -   $ WinnerImage��$��60��$��	10,0,0,10q�$��Assets/X15.png���� $ 
Horizontal=�$��Center=�.+��� -	   $ Xscore��$��40(�$��	X score: ��$��0,0,0,15q�$
��Bold"��� $ 
Horizontal=�$��Center=�.+��� -
   $ Oscore��$��40(�$��	O score: ��$��0,0,0,15q�$
��Bold"��� -   $��
Play Again��  ButtonColor#��[ $��34(�$	��200��$��60��$��0,20,0,0q�$��0,0,0,5q�
�������#��[ $��Center=�$��Center=�$
��Bold"�� -   $ StartScreen��$��2��#��[  $y�Visible=�$	��800��$	��450��.+��� $ Vertical=�$��Center=�.+��� $ 
Horizontal=�$��Center=�.+��� $��54(�$��XO NeverDraw��$��0,0,0,15q�$
��Bold"��� -   $��Start��#��[ $��34(�$	��150��$��60��$��0,20,0,0q�$��0,0,0,5q�
�������#��[ $��Center=�$��Center=�$
��Bold"��� $ 
Horizontal=�$��Bottom=�$
��Left=�$��10q�.+��� $��20(�$��Version Sigmaboi 3,6,9,12��$��0,0,0,0q�$
��Bold"�