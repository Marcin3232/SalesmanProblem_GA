   M S B A M L   `   `   `  ����F  BBionikaAPP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BionikaAPP2BionikaAPP2  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       BionikaAPP2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &oxyhttp://oxyplot.org/wpf     6@   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BionikaAPP2     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     � Title$+  %Genetic Algorithm to salesman problem��5
   	   $
��1000��67   $
��1700��6H   $
��1080��6X   $
��1920��6f   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�6s    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�   ���	#FFEFF5F4 � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ CanResizeWithGrip=�6   � SizeToContent$ Manual=�6;   � Cursor$	 Pen��6R     IsRequiredForForm$
 True��6_  	   IsRowHeader$
	 True��6�  .��5      � 
 � ColumnDefinitions
 5   
   �� 5      .+�5   
   �� $
��Left=�6   $��-633,49,0,-693q�6+   $
��1888��6C   $��/Daco_11520.png��6P    J� RenderTransformOrigin$ 0.5,0.5&�6i   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 641.889Q�6&   T� 5      5      5      �� 5   
   $
��Left=�6   $
��1063��6+   $��465,-223,0,0q�69   $	��Top=�6O   $
��1441��6g   $��/Daco_11520.png��6t   �� 5   
   $��527,829,-598,-99q�6   $��/hiclipart.com.png��6*   �� 5!   
   $
��Left=�6   $��-514,-174,0,410q�6+   $
��2701��6D   $��/Daco_11520.png��6Q   $ 0.5,0.5&�6j   z�5"      V� 5#      .~�5$      �� �� 5%      �� 5&      $ -29.055Q�6&   T� 5'      5(      5*      �� 5,   
   -   5         ��Name$ Topic��5,      $9��3Traveling salesman problem using genetic algorithms��6   $
��Left=�6]   $��
140,21,0,0q�6x   $	��Top=�6�   $��84��6�   $
��1808��6�   $
��Bold"�6�   $��56(�6�   $��Segoe UI)�6�   
���   ����	#00000000$��Normal$�6  � 5.   
   $
��1080��6    � RowDefinitions 5/      �� 50      
 52      �� 53      $	��53* �6#   �� 54      $
��187* �6#   �� 55      $
��144* �6#   .+�58      �� -   5         ��Name$ canvas��58      $��
82,174,0,0q�6%   $��2��69   $	��645��6I   $	��600��6Y   $	��645��6h   $	��600��6x   $	��Top=�6�   $	��645��6�   $
��Left=�6�   $	��625��6�    J� Effect 59      3  -System.Windows.Media.Effects.DropShadowEffect  5:      ��5<      �� 5=       �� ImageSource$ /polskamala.png��6!   5?      �� 5A      $��
Generation��6   $��10,183,5,826q�6)   $��20(�6?   $
��Bold"�6M   �� 5B      -   5         ��Name$ generationBox��5B      $��10,227,25,0q�6-   $	��100��6B    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $��39��6y   $��20(�6�   ���	#FFDEDEDE.��6   5C        5D      .��5E   "   5F      �� 5G      $��Mutation rate��6   $��
10,272,5,0q�6,   $	��Top=�6@   $��40��6X   $��20(�6d   $
��Bold"�6r   �� 5H      -   5        $ mutationrate��5H      $��10,317,25,0q�6,   $��0,015��6A   $
 Wrap=�6N   $	��Top=�6b   $��40��6  $��20(�6*  ���	#FFDEDEDE.��6O   5I        5J      .��5K   "   5L      �� 5M      $��Tournament size��6   $��
10,363,5,0q�6.   $	��Top=�6B   $��39��6Z   $��20(�6f   $
��Bold"�6t   �� 5N      -   5        $ toursize��5N      $��10,407,25,0q�6(   $��5��6=   $
 Wrap=�6F   $	��Top=�6Z   $��40��6�   $��20(�6�   ���	#FFDEDEDE.��6�    5O        5P      .��5Q   "   5R      �� 5S      $��Population size��6   $��
10,454,5,0q�6.   $	��Top=�6B   $��40��6Z   $��20(�6f   $
��Bold"�6t   �� 5T      -   5        $ populationBox��5T      $��10,502,25,0q�6-   $��50��6B   $
 Wrap=�6L   $	��Top=�6`   $��39��6�   $ 
0.489,0.53&�6�   $��20(�6�   $
��Bold"�6�   ���	#FFDEDEDE.��6   5U        5V      .��5W   "   5X      �� 5Y      $"��Select the number 
of cities��6   $��
10,566,5,0q�6?   $	��Top=�6S   $��70��6k   $��20(�6w   $
��Bold"�6�   �� 5Z      -   5         ��Name$ checkBox��5Z      $��Capitals 11 cities��6)   $��
14,650,1,0q�6F   $	��Top=�6Z   $ 0.462,0.334&�6r   $��39��6�   $��20(�6�   $
��Bold"�6�   ���	#FFDEDEDE6�   �� 5[      -   5        $ 	checkBox1��5[      $��	25 cities��6*   $��14,690,1,325q�6>   $��20(�6p   $
��Bold"�6~   ���	#FFDEDEDE6�   �� 5\      -	   5        $ 	checkBox2��5\      $��	30 cities��6*   $��14,729,1,286q�6>   $ 0.484,0.533&�6T   $��20(�6�   $
��Bold"�6�   ���	#FFDEDEDE6�   �� 5]      -
   5        $ 	checkBox3��5]      $��	50 cities��6*   $��14,766,1,249q�6>   $��20(�6p   $
��Bold"�6~   ���	#FFDEDEDE6�   �� 5^      -   5         ��Name$ button��5^      $��Start��6%   $��10,841,15,156q�65   $��25(�6a   $
��Bold"�6o   ���	#FFDEDEDE 5_        5`      5d      �� 5f      -   5         ��Name$ 
resultList��5f      $��5,164,0,600q�6+   ���	#FFDEDEDE$��1��6W    5g        5h       �� View 5j      �� 5k      .P�5l      �� 5m      5o      #  LiveCharts.Wpf.CartesianChart  5p      -   5          Name$ chart��5p   !   $	��350��60   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6Y   $ 0.5,0.5&�6p   
���   �$��255,629,0,116q�6�   $��2��6�      Series 6?   �� *series+   AxisY 5r        LiveCharts.Wpf.Axis     Title$ distance��6      MinValue$ 0Q�60      FontSize$ 18Q�6�      
Foreground
 �   �    MaxValue  6=   �� *MaxXAxisValue+!   Labels! 6a   �� *AnalysisController.Labels+5s      "   AxisX" 5v        $ 
generation��6   $ 18Q�6�   
 �   �  64   �� *MaxXAxisValue+ 6W   �� *	AxisMin+#   Unit# 6t   �� *
AxisUnit+! 5w   #   �� *AnalysisController.Labels+5x      5{      &   MaterialDesignThemes.Wpf.Flipper  5|      $
��Left=�6%   $��Center=�6@   $��0��6[   $��0��6f   �� 5~      $��Wyniki��6   $��5,117,291,0q�6%   $	��Top=�6:   $��46��6R   $
��Bold"�6^   $��24(�6p   $��2��6~   $��1��6�   �� 5      -   5        $ 
bestResult��5      $�� ��6(   $
��Left=�63   $��	5,534,0,0q�6N   $	��Top=�6a   $	��622��6y   $��40��6�   $
��Bold"�6�   $��20(�6�   $��1��6�   �� 5�      -   5        $ firstResult��5�      $�� ��6)   $
��Left=�64   $��	6,479,0,0q�6O   $	��Top=�6b   $	��609��6z   $
��Bold"�6�   $��20(�6�   $��40��6�   $��1��6�   5�      5�      5�      