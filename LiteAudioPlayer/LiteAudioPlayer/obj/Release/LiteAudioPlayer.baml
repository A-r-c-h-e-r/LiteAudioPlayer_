   M S B A M L   `   `   `  ���� J  FLiteAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LiteAudioPlayerLiteAudioPlayer       LiteAudioPlayer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:LiteAudioPlayer     -     � Title$  Lite Audio Player��$	��350��$	��700�� � WindowStartupLocation$ Manual=� � WindowStyle$
 None=� � AllowsTransparency . 
������ '  !System.Windows.Shell.WindowChrome   WindowChrome      ResizeBorderThickness$ 6q�   CaptionHeight$ 0Q�   CornerRadius$ 0��   GlassFrameThickness$ 0q�.���� -   $��Border1�����	#01121212	 �� Padding$	 1q�._��� -   $��Border2�����	#02121212$	 1q�._��� -   $��Border3�����	#04121212$	 1q�._��� -   $��Border4�����	#06121212$	 1q�._��� -   $��Border5�����	#09121212$	 1q�._��� -   $��Border6�����	#13121212$	 1q�._�� -   $��MainGrid��$��1��$��1��   	ColorMain#���   
 � RowDefinitions
 �� $��25 ��� $��25 ��� $��* ��� $��50 �.+�� -	   $��ToolBar��$��0��  ColorToolBar#���  .+��� -
   $��
StackPanel�� �� Orientation$ 
Horizontal=�$
��Left=�$��15,0,0,0q�.+��� -   $
��Icon��$��17��$��17������  �� 
TargetType" ��.���  �� Property � �� �� Value$" source/images/icons/icon.png���� -   $��label��$��Lite Audio Player��  ColorForeground#���  $��5,0,0,0q��� -   $��StackPanel1��$ 
Horizontal=�$��Right=�.+��� -   $��MinimizeButton��$��25��$��25������ " ��.���  � ��$) #source/images/tool_bar/minimize.png�� �� Triggers ��  �� Binding �� *IsMouseOver+ �� ElementName$ MinimizeButton�� �� Value True.a���  � ��$0 *source/images/tool_bar/minimize_active.png���� -   $��MaximizedButton��$��25��$��25������ " ��.���  � ��$* $source/images/tool_bar/maximized.png�� ��  �� *IsMouseOver+$ MaximizedButton�� True.a���  � ��$1 +source/images/tool_bar/maximized_active.png���� -   $��CloseButton��$��25��$��25������ " ��.���  � ��$&  source/images/tool_bar/close.png�� ��  �� *IsMouseOver+$ CloseButton�� True.a���  � ��$- 'source/images/tool_bar/close_active.png��� -    �Name$ 
Navigation��$��1�� � ColumnDefinitions �� $��5 ��� $��10 ��� $	��60* �$��60��$	��120���� $	��60* �$��60��$	��120���� $	��60* �$��60��$	��120���� $	��55* �$��55��$	��115���� $��10 ��� $��10 ��� $
��170* ��� $
��200* �$	��170��$	��300��.+��� $��0��#���  $��0,-02,-02,12.5q��� $��7��#���  $��-02,-02,0,12.5q��� $��0��#���   $��0,0,0,0q� �� CornerRadius$ 0,5,0,0���� $��1��#���  $��0,-02,-0.4,0q�$ 0,0,0,10��$��3���� $��1��#���  $��	10,-2,0,0q�$ 0,0,0,0���� $��3��#���  $��
0,-02,-1,0q�$ 0,0,0,0���� $��4��#���  $��
0,-02,-1,0q�$ 0,0,0,0���� $��5��#���  $��	0,-02,0,0q�$ 0,0,0,0���� $��6��#���  $��-05,-02,0,0q�$ 0,0,10,0���� $��7��#���   $��-0.4,0,-2,0q�$ 5,0,0,0���� -   $
��Home��$��20��$��2��$��0,0,5,5q�  ButtonStyleNavigation#��[ $
��Home��$��11(��� -   $
��List��$��20��$��3��$��0,0,5,5q�#��[ $
��List��$��11(��� -   $��Settings��$��20��$��4��$��0,0,5,5q�#��[ $��Settings��$��11(��� -   $��Other��$��20��$��5��$��0,0,0,5q�#��[ $��Other��$��11(��� -    ��Name$ Search��  TextBoxSearchStyle#��[ $��Center=�$��1��$��9��$��0,5,10,0q�$��Ebrima)��� -   $��LabelSearch��$��	Search...��$��1��$��9��#���  $��4,1,0,0q�$��Myanmar Text)� J� IsHitTestVisible .  �� -   $��SearchButton��$��1��$��9��$��0,5,15,4q�$��12��$��12��$��Bottom=�$��Right=����� " ��.���  � ��$$ source/images/icons/search.png�� ��  �� *IsMouseOver+$ SearchButton�� True.a���  � ��$+ %source/images/icons/search_active.png��� $��2��.+� � -     �Name$
 Main��  � NavigationUIVisibility$ Hidden=��� $��3��._��  �� $
��150* �$��50���� $
��400* �$	��320��$	��600���� -    �Name$ WidthColumn2��$
��150* �$��50��.+���  �� RadiusX$ 13�� �� RadiusY$ 13��$��40��$��0�� J� Opacity$
 0.65Q�$��	10,5,10,5q�$��Right=����� -   ImageAudioMain�� �� ImageSource$$ source/images/player/cover.png�� �� BitmapScalingMode$ HighQuality=��� $��1�����	#A0000000$ 15��$��40��� $��1��
 �� $��* ��� $��40 ��� $��* �.+��� -     ��Name$  slider��! �� IsMoveToPointEnabled! . " �� TickFrequency$
" 0.01Q�$	��Top=�$��
47,6,47,10q�$��1��# � Value# �� *CurrentFrame+{��� *	IsPause+�� -   $ ��Name$$ LabelPlaerLeft��$��00:00��$
��Left=�$��10,2,0,0q�$	��Top=�$��2��#���  �� -   $$ LabelPlaerRight��$��00:00��$��Right=�$��0,2,10,0q�$	��Top=�$��2��#���  �� -   $��PlayPauseButton��$ 1Q�$#��source/images/player/play.png��$��Bottom=�$��Center=�$��2��$��23��$��23��$��	0,0,0,2.5q��� -    $��
NextButton��$#��source/images/player/next.png��$��Bottom=�$��Center=�$��2��$��20��$��20��$��50,0,0,4q��� -!   $��
BackButton��$#��source/images/player/back.png��$��Bottom=�$��Center=�$��2��$��20��$��20��$��	-60,0,0,4q��� -"   $��	MixButton��$"��source/images/player/mix.png��$��Bottom=�$��Right=�$��2��$
��14.5��$
��14.5��$��
0,0,75,6.5q��� -#   $��RepeatButton��$%��source/images/player/repeat.png��$��Bottom=�$��Right=�$��2��$
��14.5��$
��14.5��$��
0,0,49,6.5q��� -$   $��
ListButton��$#��source/images/player/list.png��$��Bottom=�$��Right=�$��2��$��16��$��16��$��
0,0,20.5,6q��� -%   $��VolumeButton��$%��source/images/player/volume.png��$��Bottom=�$
��Left=�$��2��$
��14.5��$��18��$��22.5,0,20.5,7q��� -&   $  VolumeSlider��! . $
" 0.01Q�$
��Left=�$��Bottom=�$��0��$��40.5,0,22,9q�$��1��# �� *CurrentFrame+{��� *	IsPause+� -'   $��GridCurrentFolderList��$��2��$	��200��$	��127��$	��200��$��10,-200,10,5q�$
 0.65Q�$��Bottom=�$
��Left=�.+��� ���	#A0000000$ 15��._��� $��0,15,-14,15q�.���  �� $��37 ��� $��* �.+��� -(   % ��Name$% StackPanelCoverList��$��0��$��0,0,2,0q�
����� ��� -)   $!% StackPanelCurrentFolderList��$��1��$��0,0,2,0q�& J� BitmapEffect& F� ' F� 	Direction$' 0Q�( F� ShadowDepth$( 0Q�) F� Softness$	) 0.2Q�