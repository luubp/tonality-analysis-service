   M S B A M L   `   `   `  ����U  QScottPlot.WPF, Version=4.1.68.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aa<.clr-namespace:ScottPlot;assembly=ScottPlot.WPF	ScottPlot  5   	   A =client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1 5   	      WpfApp1.MainWindow   5   	   <	ScottPlot.clr-namespace:ScottPlot;assembly=ScottPlot.WPF  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  ДПП М8О-304Б-21��5
   	   $	��532��6!   $	��800��6.   ��5      �� 5   
    �� ImageSource$ background.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ textBox1��5      $��
53,96,0,85q�6$   $��Введите текст��68    �� TextWrapping$
 Wrap=�6M   $��Microsoft JhengHei)�6a   
������� J� RenderTransformOrigin$ 1,0.015&�6�   $
��Left=�6�   $	��312��6�   .��6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ 0Q�6$   �� 5      T� 5       T� Y$ 0Q�6)   5      .��5   '   5      �� 5   
   -   5        $��Отправить��5      $��	96,0,0,31q�6%   $��Microsoft JhengHei)�68   $
��Left=�6m   $	��176��6�   $��26��6�   $��Bottom=�6�   o� 5   
   $��17��6   $	��Top=�6   $��Lucida Console)�63   ���	#FFBEDCD1.@�5      m� $��Файл��6   $��Microsoft JhengHei)�6%   .@�5      m� -   5        $��Открыть��5      $��Microsoft JhengHei)�6,   6L   m� 5      -   5        $+��%Сохранить результат��5      $��Microsoft JhengHei)�68   6X   5      m� 5       -   5        $��Справка��5       $��Microsoft JhengHei)�6(   6H   m� 5!      $��Вид��6   $��Microsoft JhengHei)�6$   5"      �� 5#   
   $��Ваш текст��6   $��	68,68,0,0q�6$   $��MV Boli)�67   $��28��6L   $	��Top=�6X   $
��Left=�6p   $��72��6�   
�������$
��Bold"�6�   ��6�   Z� 6�   �� 5$   
   $��Результат��6   $��
0,68,292,0q�6$   $��MV Boli)�68   $��Right=�6M   $��80��6i   $��28��6t   $	��Top=�6�   $
��Bold"�6�   
�������6�   �� 5%   
   -   5         ��Name$ pozitive��5%      $1��+Положительная 
окраска��6"   $��1��6L   $
��Left=�6\   $��377,365,0,0q�6w   $	��Top=�6�   $	��102��6�   $��44��6�   $y�Hidden=�6�   �� 5&   
   -   5        $ neutral��5&      $-��'Нейтральная 
окраска��6!   $��1��6I   $
��Left=�6Y   $��484,365,0,0q�6t   $	��Top=�6�   $��93��6�   $��51��6�   $y�Hidden=�6�   �� 5'   
   -   5        $ negative��5'      $-��'Негативная 
окраска
��6"   $��1��6S   $
��Left=�6c   $��591,364,0,0q�6~   $	��Top=�6�   $��91��6�   $��46��6�   $y�Hidden=�6�      ScottPlot.WpfPlot  5(   
   -	   5          Name$ Chart��5(      $��400,96,55,85q�6+   $ 0.014,0.011&�6A   )  #MahApps.Metro.Controls.ProgressRing  5)   
   -
   5        	  Name$	 download��5)      
   IsActive$

 True��6-   $y�Hidden=�6=   ���	#FF06AD7A$
��Left=�6h   $��542,234,0,0q�6�   $	��Top=�6�   � 5*   
   -   5         �Name$ loadingProgressBar��5*       � IsIndeterminate$
 True��62   $y�	Collapsed=�6I   $��Center=�6`   $��Center=�6}   $��1��6�   $��10��6�   $��412,387,0,0q�6�   $	��100��6�   �� 5+   
   -   5        $ labelFileName��5+      $��Label��6'   $��164,68,0,419q�67   $y�Hidden=�6M   $��MV Boli)�6a   $
��Bold"�6v   
�������$
��Left=�6�   $��40��6�   ��6�   Z� 6�   50      51      