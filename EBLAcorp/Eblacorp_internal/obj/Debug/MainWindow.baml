   M S B A M L   `   `   `  ����L  HEblacorp_internal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Eblacorp_internalEblacorp_internal  5   	   I)clr-namespace:Eblacorp_internal.ViewModelEblacorp_internal.ViewModel  5   	   A%clr-namespace:Eblacorp_internal.ViewsEblacorp_internal.Views  5   	   "    Eblacorp_internal.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Eblacorp_internal     5   	   @
viewmodels)clr-namespace:Eblacorp_internal.ViewModel     5   	   7views%clr-namespace:Eblacorp_internal.Views     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1024��6)    � 	Resources 5       �� DataType3   -Eblacorp_internal.ViewModel.EmployeeViewModel*   $Eblacorp_internal.Views.EmployeeView � DataContext2   ,Eblacorp_internal.ViewModel.CompanyViewModel)   #Eblacorp_internal.Views.CompanyView��%�   (��       5   1   *, +)(�� U     5   0   *, +)�� 5   
   EmployeeTemplate��"  61   .R�5         6!   �� 5      �� 5   
   CompanyTemplate��"  60   .R�5         6    �� 5      5      .��5      � ��5   
   �� 5       �� ImageSource$ assets/triangles.png��6    �� Opacity$
 0.33Q�6<    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5       $
��5.5* �6   .+�5#   
   �� ._�5$      �� $��0��6   .+�5'      �� $��20 0 0 0q�6   $��assets/Ebla_logo_noBg.png��6*   6O   �� 5*      -   5         ��Name$ HomeBtn��5*   C   
�������$
��Home��6T   $��
20 5 20 20q�6c   6y   �� 5+      -   5        $ EmployeeBtn��5+   G   
�������$��Employee��6\   $��20q�6o   6}   �� 5,      -   5        $ 
CompanyBtn��5,   F   
�������$��Company��6Z   $��20q�6l   6z   �� 5-      -   5        $ 	BranchBtn��5-   E   
�������$��Branch��6X   $��20q�6i   6w   �� 5.      -   5        $ DelegateBtn��5.   G   
�������$��Delegate��6\   $��20q�6o   6}   �� 5/      $��Reports��6   $��20q�6*   68   �� 50      -   5        $ Report1��50   M   ���	#FFB6B8E6$��Report1��6^   $��20q�6p   6~   �� 51      -   5        $ Report2��51   N   ���	#FFB6B8E6$��Report2��6_   $��20q�6q   6   �� 52      -   5        $ Report3��52   G   ���	#FFB6B8E6$��Report3��6X   $��20q�6j   6x   �� 55      -	   5        $ CloseBtn��55   0   ���	#FFDAA155$��Close��6B   $��20 10 20 20q�6R   6�   5:      5=      �� 5?   
   $��1��6.   ��6   �� 5A      5C      5e      