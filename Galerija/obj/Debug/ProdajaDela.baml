   M S B A M L   `   `   `  ����C  ?Galerija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GalerijaGalerija  5   	       Galerija.ProdajaDela   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Galerija     5   	     � Title$  ProdajaDela��5   	   $	��350��6   $	��650��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      � #��� ��6    � RowDefinitions 5
   
   �� 5      .+�5   
   �� -   5        $��Unesi��5      $
��Left=�6!   $��
425,23,0,0q�6<   $	��Top=�6P   $	��100��6h   $��30��6t   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $��Izmeni��5      $
��Left=�6"   $��
425,65,0,0q�6=   $	��Top=�6Q   $	��100��6i   $��30��6u   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $��Obrisi��5      $
��Left=�6"   $��425,110,0,0q�6=   $	��Top=�6R   $	��100��6j   $��30��6v   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridProdajaDela��5      $��0,162,10.2,0q�60   $	��Top=�6F    J� RenderTransformOrigin$ 4.054,11.938&�6�   $	��149��6�   $��Right=�6�   $	��623��6�   ���	#FFE5E5E5$��HP Simplified Light)�6�   $��14(�6  $��3q�6-  �� 5   
   -   5         ��Name$ CenaProdaje��5      $
��Left=�6'   $��23��6B   $��
150,71,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   -   5        $ BrojProdaje��5      $
��Left=�6'   $��23��6B   $��
150,15,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��HP Simplified Light)�6�   $��14(�6�   $��2q�6�   �� 5   
   $��BrojProdaje��6   $
��Left=�6&   $��	70,15,0,0q�6A   $	��Top=�6T   $��HP Simplified Light)�6l   $��14(�6�   �� 5   
   $��DatumProdaje��6   $
��Left=�6'   $��	54,41,0,0q�6B   $	��Top=�6U   $��HP Simplified Light)�6m   $��14(�6�   �� 5   
   $��CenaProdaje��6   $
��Left=�6&   $��	65,71,0,0q�6A   $	��Top=�6T   $��HP Simplified Light)�6l   $��14(�6�   �� 5   
   $��DelaID��6   $
��Left=�6!   $��	99,99,0,0q�6<   $	��Top=�6O   $��HP Simplified Light)�6g   $��14(�6�   �� 5   
   -   5        $��Izlaz��5      $
��Left=�6!   $��
573,10,0,0q�6<   $	��Top=�6P   $��60��6h   $��HP Simplified Light)�6�   $��14(�6�   $��30��6�   �� 5   
   $��	KlijentID��6   $
��Left=�6$   $��
91,127,0,0q�6?   $	��Top=�6S   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumProdaje��5      $
��Left=�6+   $��
150,43,0,0q�6F   $	��Top=�6Z   �� 5   
   -	   5         ��Name$ 	txtDelaID��5      $
��Left=�6&   $��
150,99,0,0q�6A   $	��Top=�6U   $	��120��6m   6y   �� 5   
   -
   5        $ 	KlijentID��5      $
��Left=�6&   $��150,130,0,0q�6A   $	��Top=�6V   $	��120��6n   6z   5      5      