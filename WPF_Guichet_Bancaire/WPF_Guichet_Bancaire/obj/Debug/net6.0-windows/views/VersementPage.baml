   M S B A M L   `   `   `  ����O  KWPF_Guichet_Bancaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WPF_Guichet_Bancaire.viewsWPF_Guichet_Bancaire.views  5      .    (WPF_Guichet_Bancaire.views.VersementPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:WPF_Guichet_Bancaire.views     5        N� Title$  VersementPage��5	       N� 
Background �#30336b.��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��70 �6   �� 5      �� 5      $��40 �6   .+�5   
    � -   5          �Name$ MainVersement��5      $��1��6     � NavigationUIVisibility$ Hidden=�64   �� 5   
   $��0��6   ���#130f406!   �� 5   
   $��19(�6   
�������$��Center=�65   $��0,5,0,0q�6R   64Faite un versement rapidement et en toute sécurité6�   �� 5   
   -   5         ��Name$ stackBtnCompte��5       �� Orientation$ 
Horizontal=�6-   $��1��6F   $	��top=�6S   $��	20,20,0,0q�6k   .+�5      	� -   5         	�Name$ 
btnEpargne��5      $��0,0,20,0q�6.   
�������.��6S   	Epargne6\   	� 5      -   5        $ 
btnCourant��5      
�������.��6A   	Courant6J   5      �� 5   
   $��2��6   $ Vertical=�6"   .+�5      �� 
�������$��16(�6+   $��20,5,0,0q�69   *(Entrer la somme que vous voulez verser :6u   �� 5      -   5         ��Name$ txbSommeVerse��5      $	��200��6-   $
��Left=�69   $��	20,10,0,0q�6T   5      � 5    
   -   5        	 �Name$	 boxAfficheCompte��5       $��3��6    5!      �� 5"      $��* �6    �� 5#      $��* �6    .+�5&      �� -   5        $ stackEpargne��5&      $��0��6/   $ Vertical=�6<   5'      �� 5)      -   5        $ stackCourant��5)      $��1��6/   $ Vertical=�6<   5*      5+      �� 5-   
   -	   5        
 ��Name$
 validerVersement��5-      $��4��6+   $��Center=�68   $��80��6S   $
��Left=�6^   $��20,0,0,0q�6y   .��6�   	Valider6�   5.      5/      