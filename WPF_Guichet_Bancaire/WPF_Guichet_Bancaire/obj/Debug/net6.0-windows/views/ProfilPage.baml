   M S B A M L   `   `   `  ����O  KWPF_Guichet_Bancaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WPF_Guichet_Bancaire.viewsWPF_Guichet_Bancaire.views  5      +    %WPF_Guichet_Bancaire.views.ProfilPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:WPF_Guichet_Bancaire.views     5        N� Title$  
ProfilPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��60* �6   �� 5      $	��20* �6   .+�5   
   �� $��0��6   ���#130f406!   �� 5   
   $��Modifier votre profil.��6   
�������$��26(�6E   $
��Bold"�6S   $��Center=�6e   $��Center=�6�   � 5   
   $��1��6    � Orientation$ Vertical=�6!   ���#30336b.+�5      �� $��Nom :��6   $��16(�6%   $��	20,10,0,0q�63   
�������6F   �� 5      -   5         ��Name$ txtNom��5      $	��300��6&   $
��Left=�62   $��20,5,0,0q�6M   �� 5      $��Prenom:��6   $��16(�6'   $��	20,10,0,0q�65   
�������6H   �� 5      -   5        $ 	txtPrenom��5      $	��300��6)   $
��Left=�65   $��20,5,0,0q�6P   �� 5      $��Email:��6   $��16(�6&   $��	20,10,0,0q�64   
�������6G   �� 5      -   5        $ txtEmail��5      $	��300��6(   $
��Left=�64   $��	20,10,0,0q�6O   �� 5      $��Mot de passe :��6   $��16(�6.   $��	20,10,0,0q�6<   
�������6O   �� 5      -   5        $ txtMdp��5      $	��300��6&   $
��Left=�62   $��
20,10,0,20q�6M   �� 5      $��Date de naissance :��6   $��16(�63   $��20,8,0,0q�6A   
�������6S   �� 5      -   5        $ txtDate��5      $	��300��6'   $
��Left=�63   $��20,5,0,0q�6N   �� 5      $��
Votre Id :��6   $��16(�6*   $��20,8,0,0q�68   
�������6J   �� 5      -   5        $ txtId��5      $	��300��6%   $
��Left=�61   $��20,5,0,0q�6L   5       �� 5!   
   $��2��6   ���#130f40 �� Orientation$ 
Horizontal=�67   .+�5"      �� $)��#Moddifier votre profil en un clic !��6   $��Center=�6C   $��17(�6^   
�������6l   �� 5#      -   5         ��Name$ btnModif��5#      $	��100��6'   $��20��63   $��20,0,0,0q�6?   .��6Q   
Modifier6[   5$      5%      5&      