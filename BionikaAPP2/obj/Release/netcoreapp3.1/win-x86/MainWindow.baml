   M S B A M L   `   `   `  ���� F  BBionikaAPP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BionikaAPP2BionikaAPP2  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     BionikaAPP2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &oxyhttp://oxyplot.org/wpf     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:BionikaAPP2     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf    � Title$+  %Genetic Algorithm to salesman problem��$
��1000��$
��1600��$
��1080��$
��1920��4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=����	#FFEFF5F4 � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ CanResizeWithGrip=� � SizeToContent$ Manual=� � Cursor$	 Pen��   IsRequiredForForm$
 True��	   IsRowHeader$
	 True��.��� 
 � ColumnDefinitions
 �� $��7* ��� $
��280* ��� $��4* ��� $	��12* ��� $
��911* ��� $
��599* ��� $
��107* �.+��� $
��Left=�$��-633,49,0,-693q�$
��1888��$��/Daco_11520.png�� J� RenderTransformOrigin$ 0.5,0.5&�$��6��z�V� .~��� �� ��  �� Angle$ 641.889Q�T� �� $
��Left=�$
��1063��$��510,-223,0,0q�$	��Top=�$
��1441��$��/Daco_11520.png��$��4��$��3���� $��111,844,-182,-114q�$��/hiclipart.com.png��$��5��$��2���� $
��Left=�$��-514,-174,0,410q�$
��2701��$��/Daco_11520.png��$ 0.5,0.5&�$��7��z�V� .~��� �� �� $ -29.055Q�T� �� -    ��Name$ Topic��$9��3Traveling salesman problem using genetic algorithms��$
��Left=�$��
140,21,0,0q�$	��Top=�$��84��$
��1808��$
��Bold"�$��56(�$��Segoe UI)�
���   ����	#00000000$��Normal$�$��1��$��6��� $��7�� � RowDefinitions �� $
��161* ��� $	��29* ��� $
��351* ��� $
��296* ��� $
��227* �
 �� $	��11* ��� $
��346* ��� $
��795* ��� $	��65* ��� $
��593* ��� $
��110* �.+��� -    ��Name$ 
resultList��$��292,157,13,47q�$��2��$��3�����	#FFDEDEDE$��1�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect   �� View �� .P��� � $��3��$��306,123,7,50q�$��2��$��1��$��2��.+�#  LiveCharts.Wpf.CartesianChart  -     Name$ chart��&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�$��Right=�$	��833��$��	0,0,-5,-5q�$ 0.5,0.5&�
���   �   Series �� *series+   AxisY   LiveCharts.Wpf.Axis     Title$ distance��   MinValue$ 0Q�   FontSize$ 18Q�   
Foreground
 �   �   MaxValue �� *MaxXAxisValue+   Labels �� *AnalysisController.Labels+   AxisX   $ 
generation��$ 18Q�
 �   � �� *MaxXAxisValue+ �� *	AxisMin+   Unit �� *
AxisUnit+ �� *AnalysisController.Labels+&   MaterialDesignThemes.Wpf.Flipper  $
��Left=�$��349,174,0,0q�$	��Top=��� $��1q�$��2,128,68,109q�$��5��$��1��$	��276�� J� OpacityMask ��  �� EndPoint$ 0.5,1&�  �� 
StartPoint$  0.5,0&�.��� ! � Color$! Black��� $! White��" � Offset$" 1Q�._��  �� $	��580 �
 �� $��1.006 ��� $	��275 ��� $��9.432 �.+��� -   # ��Name$# button��$��Start��$��0,638,5,-110q�$��25(�$
��Bold"����	#FFDEDEDE$��2��   �� -   $ ��Name$$ generationBox��$��	0,60,11,0q�$	��100��% �� TextWrapping$
% Wrap=�$	��Top=�$��40��$��20(����	#FFDEDEDE$��2��.��   .���� -   $$ mutationrate��$��
0,151,11,0q�$��0,015��$
% Wrap=�$	��Top=�$��40��$��20(����	#FFDEDEDE$��2��.��   .���� $��
Generation��$��
0,16,0,524q�$��20(�$
��Bold"�$��40��$��3���� $��Mutation rate��$��	0,106,0,0q�$	��Top=�$��40��$��20(�$
��Bold"�$��3���� -   $$ toursize��$��
0,242,11,0q�$��5��$
% Wrap=�$	��Top=�$��40��$��20(����	#FFDEDEDE$��2��.��   .���� $��Tournament size��$��	0,197,0,0q�$	��Top=�$��40��$��20(�$
��Bold"�$��3���� $��Population size��$��	0,289,0,0q�$	��Top=�$��40��$��20(�$
��Bold"�$��3���� -   & ��Name$& checkBox��$��Capitals 11 cities��$��	0,458,0,0q�$	��Top=�$ 0.462,0.334&�$��40��$��20(�$
��Bold"����	#FFDEDEDE$��3���� -	   $& 	checkBox1��$��	25 cities��$��
0,499,0,41q�$��40��$��20(�$
��Bold"����	#FFDEDEDE$��3���� -
   $& 	checkBox2��$��	30 cities��$��	0,538,0,2q�$ 0.484,0.533&�$��40��$��20(�$
��Bold"����	#FFDEDEDE$��3���� -   $$ populationBox��$��
0,337,11,0q�$��50��$
% Wrap=�$	��Top=�$��40��$ 
0.489,0.53&�$��20(�$
��Bold"����	#FFDEDEDE$��2��.��   .���� -   $& 	checkBox3��$��	50 cities��$��0,575,0,-35q�$��40��$��20(�$
��Bold"����	#FFDEDEDE$��3���� $!��Choose the number of cities��$��	0,397,0,0q�$	��Top=�$��40��$��20(�$
��Bold"�$��3���� -   ' ��Name$' canvas��$��62,3,106,226q�$	��645��$	��600��$��3��$��3��$��2��$��3��   ���� ( �� ImageSource$( /polskamala.png���� $��Wyniki��$��314,117,291,0q�$	��Top=�$��46��$��2��$
��Bold"�$��24(�$��1��$��2���� -   $ 
bestResult��$�� ��$
��Left=�$��
308,41,0,0q�$	��Top=�$��2��$	��622��$��40��$��3��$
��Bold"�$��20(�$��1���� -   $ firstResult��$�� ��$
��Left=�$��308,338,0,0q�$��2��$	��Top=�$	��609��$
��Bold"�$��20(�$��40��$��2��$��2��$��1��