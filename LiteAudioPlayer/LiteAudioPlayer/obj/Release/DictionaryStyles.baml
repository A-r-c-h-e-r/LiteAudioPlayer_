   M S B A M L   `   `   `  ���� J  FLiteAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LiteAudioPlayerLiteAudioPlayer  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ColorToolBar  �� Color  	ColorMain  ColorForeground  ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton N� EnterActions �� 
TargetName �� TargetProperty g� Duration W� From	 W� To �� Angle  SliderRepeatButtonStyle1  TextBoxSearchStyle ��Name  SliderRepeatButtonStyle2  HorizontalSliderThumbStyle J� BitmapEffect F� Color F� 	Direction F� ShadowDepth F� Softness  J� SnapsToDevicePixels! � RowDefinitions" m�Name# m� Fill$ m� 	Placement% �� DecreaseLarge& �� IncreaseLarge  ButtonStyleNavigation 	 ActiveButtonStyleNavigation' �� BasedOn�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     'localclr-namespace:LiteAudioPlayer  %�  &	        &	 )     &	 O     &	 {     '�� �    7  &	 '    &	      &	 �    &	 /    '�� l	    7  7  7  &	 �    &		 �    7  �� -   ColorToolBar��$  #111111���� -   	ColorMain��$  #252525���� -   ColorForeground��$  #CCCCCC���� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $	��5.5��$
��Auto��
������ �� $ ScrollBarRectangle��$ 3��$��Stretch=�$��Stretch=�$	��5.5��$
��Auto�����#717171 P� 	 �@�Tag$
 
Horizontal��. ��� $ ScrollBarRectangle�� � ��$	 5.5���� $ ScrollBarRectangle�� � ��$ 7���� " ��.���  � ��$ 
-5,10,0,10q���  �@��IsFlicksEnabled .  ��  � �� �	#FF8C8C8C��  � �� �#414141��  � ��$	 5.5����  � �� �� " ��.R��� $��opacityAnimated��$ 3��$	��5.5��#��z��._�� $ GridRoot��$	��5.5��
������ .+�]� $ 
PART_Track����. |�.   n� $ ScrollBarThumb��#��z��8��   �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.   P� 	 � {�
 .  . ��� $ ScrollBarThumb�� � y�$ 	Collapsed=���  � ��
 ���� P� 	 � {�
 .  �� .���� .��W� $ opacityAnimated��$ (Border.Opacity)�$ 0:0:3D�$ 0X�$ 10X�P� 	 �@��Orientation$
 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$	 5.5����  � ��$ 8���� $ ScrollBarThumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� $ 2��$	��5.0��$��4,0,-4,0q�$��center=�._�� .+��� ���	#70ffffff$ 2���� " ��.���  � �� �	#A0101010��  � ��
 �������  � �� �� " ��.R��� $ 8��#��z��._��� $ PART_ContentHost��$��7,2,0,2q��� " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� " n�.���  � |� .  ��  �@�OverridesDefaultStyle . ��  � ��$ 10����  � ��$ 10����  � �� �	#FFA0A0A0��  � �� �� " n�.R�A� #��z��$	��0.4�� F� $ Black��$ 2Q�$ 0Q�$	 0.4Q� P� 	 �@J�IsMouseOver
 . . ���  � �� �	#FFC8C8C8�� " ��.���  �@��IsPressAndHoldEnabled .  ��  � ��
 ���� ��  � ��
 �������  � �� �� " ��.R��� #��z��#��z��#��z��  . ._�� ! �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $" TopTick��## z��$��4��$	$ Top=�$��0��$y�	Collapsed=�m� $" 
BottomTick��## z��$��4��$$ Bottom=�$��2��$y�	Collapsed=��� $ TrackBackground��$ 2��$	��5.0��$	��5,0q�$��1��$��center=�._�� .+��� ���	#FF4C4C4C$ 2��]� $ 
PART_Track��$��1�� �� #��Z% 8��   �� #��Z& 8��  n� $ Thumb��8�� �� " ��.���  � �� �	#10FFFFFF��  � �� �#EBEBEB��  � �� �� " ��.R��� $ 9��#��z��._��� #��z��#��z�� P� 	 �@J�IsMouseOver
 . . ���  � �� �	#30FFFFFFP� 	 � ��
 . . ���  � �� �	#50FFFFFF��  � �� �#222222�� " ��8'   .���  � �� �	#30FFFFFF��  � �� �#ffffff