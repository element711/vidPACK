   M S B A M L   `   `   `  ����  VidPackAdmin(    "VidPackAdmin.View.Controls.Setting   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      � -   5          �Name$  grdMain��5	      $��20q�6    � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��2��6!   $��Oblique$�65   $
��Bold"�6I   Backend Configuration6r   �� 5   
   $��1��6   $��0��6   $��Backend Uri��6.   �� 5    
   -   5        $��1��5       $��1��6   $��5q�6/   ��6:   �� *LocalConfiguration.BackendUrl+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5"   
   $��3��6   $��2��6!   $��Oblique$�65   $
��Bold"�6I   Notification Hubs6n   �� 5#   
   $��4��6   $��0��6   $��Connection String��6.   �� 5$   
   -   5        $��4��5$      $��1��6   $��5q�6/   ��6:   �� *53LocalConfiguration.NotificationHub_ConnectionString+$ PropertyChanged=�6�   �� 5%   
   $��5��6   $��0��6   $��Hub Path��6.   �� 5&   
   -   5        $��5��5&      $��1��6   $��5q�6/   ��6:   �� *,*LocalConfiguration.NotificationHub_HubPath+$ PropertyChanged=�6�   �� 5(   
   $��7��6   $��2��6!   $��Oblique$�65   $
��Bold"�6I   Media Services6k   �� 5)   
   $��8��6   $��0��6   $��Account Name��6.   �� 5*   
   -   5        $��8��5*      $��1��6   $��5q�6/   ��6:   �� *.,LocalConfiguration.MediaServices_AccountName+$ PropertyChanged=�6�   �� 5+   
   $��9��6   $��0��6   $��Account Key��6.   �� 5,   
   -   5        $��9��5,      $��1��6   $��5q�6/   ��6:   �� *-+LocalConfiguration.MediaServices_AccountKey+$ PropertyChanged=�6�   5-      5.      