   M S B A M L   `   `   `  ����K  GAssignment 2 WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Assignment_2_WPFAssignment_2_WPF  5   	   (    "Assignment_2_WPF.LanguageSelection   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Assignment_2_WPF     5   	   -   5          � Title$  LanguageSelection��5   	   $	��800��6#   $
��1000��60    � 	Resources 5	       �� 	UriSource   emptyStarBitmap  filledStarBitmap��%}   &	        &	 4     �� 5
   
   $ images/empty_star.png?�6   6R   �� 5   
   $ images/filled_star.png?�6   6U   5      .��5      �  � RowDefinitions 5   
   �� 5      -   5         �Name$ ToolBar��5      $
��Auto �6+   6;   �� 5      -   5        $ LabelHolder��5      $
��Auto �6/   6?   �� 5      -   5        $ TabControls��5      $��* �6/   6<   .+�5   
   o�  o� 
IsMainMenu . $��0��6!   .@�5      m� $��_File��6   .@�5      m� $��_New Save List��6    m� Icon 5      �� 5      $��images/newicon.jpg��6    5      m� 5      $��_Open Save List��6    5       �� 5!      $��images/openicon.png��6    5#      5&      m� 5'      $��	_Language��6   .@�5(      m� -   5        $��ToolBarLangSelect��5(   8   $��_Language Selection��6    5)      �� 5*      $��images/openlanguage.png��6    5,      5-      m� 5/      $��_Help��6   50      �� 51   
   -   5         ��Name$ LblTranslator��51      $��Center=�6'   $��Center=�6D   $��Center=�6h   $��Center=�6�   $��
Translator��6�   $��Tahoma)�6�   $��70(�6�   $��
ExtraBlack"�6�   $��1��6�   $	��5,0q�6  � 53   
   $��2��6   .+�56      �� -   5         ��Name$ 
tabControl��56      $��Stretch=�6-   $��Stretch=�6R   .@�57      �� $��Common Phrases��6   .��59      � ���	#FFE5E5E5$��5q�62    5;      �� 5<      $
��Auto �6,   6<   �� 5=      $��* �6,   69   .+�5B      �� $��0��6#   $��Right=�60   $��Right=�6S   $��Center=�6o   $��Center=�6�   $��1��6�   $��	0,0,0,0.4q�6�   6�   �� 5D      -   5        	 ��Name$	 CommonPhraseListView��5D   #   $��1��6A   $��10q�6N   $��2��6Z   ��6n   �� *AllCommonPhrases+��5M      �� 5N   "   .R�5O   &   �� $��5q�6-   ���	#FF1986D1$��Center=�6Y   ._�5P   *   � 
 � ColumnDefinitions
 5Q   .   �� 5R   2   $
��Auto �6C   �� 5S   2   $��* �6C   �� 5T   2   $
��0.4* �6C   .+�5X   .   �� $��32��6Q   $��32��6\   $��0��6h   ��64   �� *	ImagePath+��5Y   2   �� 5Z   6    �� 
TargetType" ��6<   .�5[   :   -	   5        5\   7   5^   /   �� 5`   .   $
��Left=�6Q   $��Stretch=�6s   $��Center=�6�   $��1��6�   ��64   �� *
FromLang+6�   �� 5a   .   $��Stretch=�6O   $
��Left=�6m   $��Center=�6�   $��2��6�   ��64   �� *ToLang+6�   �� 5b   .   $y�	Collapsed=�6K   $��2��6b   ��64   �� *Id+6t   �� 5c   .   $y�	Collapsed=�6S   $��2��6j   ��64   �� *
IdToItself+6|   5g   +   5h   '   5i   #   5k      5l      5m      �� 5n      $��TabItem��6   .��5o      � ���	#FFE5E5E56   5p      5q      5r      5u      5w      