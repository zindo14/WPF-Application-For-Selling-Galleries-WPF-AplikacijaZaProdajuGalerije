   M S B A M L   `   `   `  ����C  ?Galerija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GalerijaGalerija  5   	       Galerija.Autori   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Galerija     5   	     � Title$  Autori��5   	   $	��350��6   $	��650��6%    � WindowStartupLocation$ CenterScreen=�61   .��5	      � #��� ��6    � RowDefinitions 5
   
   �� 5      .+�5   
   �� -   5        $��Unesi��5      $
��Left=�6!   $��
450,28,0,0q�6<   $	��Top=�6P   $	��100��6h   $��30��6t   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $��Izmeni��5      $
��Left=�6"   $��
450,68,0,0q�6=   $	��Top=�6Q   $	��100��6i   $��30��6u   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $��Obrisi��5      $
��Left=�6"   $��450,108,0,0q�6=   $	��Top=�6R   $	��100��6j   $��30��6v   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridIzlozba��5      $��0,162,10.2,0q�6,   $	��Top=�6B    J� RenderTransformOrigin$ 4.054,11.938&�6�   $	��149��6�   $��Right=�6�   $	��623��6�   $��3q�6�   $��HP Simplified Light)�6�   $��14(�6  ���	#FFE5E5E56&  �� 5   
   -   5         ��Name$ txtIme��5      $
��Left=�6"   $��23��6=   $��
122,38,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $ 
txtPrezime��5      $
��Left=�6&   $��23��6A   $��
122,66,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $ 
txtAutorID��5      $
��Left=�6&   $��23��6A   $��
122,10,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ GodinaRodjenja��5      $
��Left=�6-   $��
140,94,0,0q�6H   $	��Top=�6\     5   
   -	   5        $ GodinaSmrti��5      $
��Left=�6*   $��140,122,0,0q�6E   $	��Top=�6Z   �� 5   
   $��AutorID��6   $
��Left=�6"   $��47,7,0,0q�6=   $	��Top=�6O   $��HP Simplified Light)�6g   $��14(�6�   $ 0.638,0.602&�6�   �� 5   
   $	��Ime��6   $
��Left=�6   $��	69,37,0,0q�69   $	��Top=�6L   $��HP Simplified Light)�6d   $��14(�6�   �� 5   
   $��Prezime��6   $
��Left=�6"   $��	44,63,0,0q�6=   $	��Top=�6P   $��HP Simplified Light)�6h   $��14(�6�   �� 5   
   $��Godina rodjenja��6   $
��Left=�6*   $��	23,93,0,0q�6E   $	��Top=�6X   $��HP Simplified Light)�6p   $��14(�6�   �� 5   
   $��Godina smrti��6   $
��Left=�6'   $��
39,121,0,0q�6B   $	��Top=�6V   $��HP Simplified Light)�6n   $��14(�6�   �� 5   
   -
   5        $��Izlaz��5      $
��Left=�6!   $��
573,10,0,0q�6<   $	��Top=�6P   $��60��6h   $��HP Simplified Light)�6�   $��14(�6�   $��30��6�   �� 5   
   -   5        $ txtBiografija��5      $
��Left=�6)   $	��114��6D   $��
260,33,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��170��6�   �� 5   
   $��
Biografija��6   $
��Left=�6%   $��
260,10,0,0q�6@   $	��Top=�6T   5      5       