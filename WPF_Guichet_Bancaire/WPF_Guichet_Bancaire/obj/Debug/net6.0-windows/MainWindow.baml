   M S B A M L   `   `   `  ����O  KWPF_Guichet_Bancaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Guichet_BancaireWPF_Guichet_Bancaire  5   	   %    WPF_Guichet_Bancaire.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WPF_Guichet_Bancaire     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� $��0��6   ���#30336b6$   �� 5   
   -   5         ��Name$ 	stackMenu��5   %   $��0��6   $	��150��69   $	��100��6F   $
��Left=�6R    �� Orientation$ Vertical=�6m   $	��Top=�6�   .+�5      �� -   5         ��Name$ btnCrediter��5   ;   $��70��6   $
��Left=�6    .��6P   
Crediter6Z   �� 5      -   5        $ btnVersement��5   ;   $��70��6   $
��Left=�6    .��6Q   	Versement6\   �� 5      -   5        $ 
btnRetrait��5   ;   $��70��6   $
��Left=�6    .��6O   	Retrait6X   �� 5      -   5        $ btnInfoCompte��5   ;   $��70��6   $
��Left=�6    .��6R   Infos Compte6`   �� 5      -   5        $ 	btnProfil��5   ;   $��70��6   $
��Left=�6    .��6N   Profil6V   �� 5      -   5        $ btnDeconnexion��5   ;   $��70��6   $
��Left=�6    .��6S   Deconnexion6`   5       � 5   
   -   5          �Name$
 Main��5       $��1��6     � NavigationUIVisibility$ Hidden=�6.   5      5      