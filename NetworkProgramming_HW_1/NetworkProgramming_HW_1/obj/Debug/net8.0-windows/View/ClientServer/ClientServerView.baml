   M S B A M L   `   `   `  ����R  NNetworkProgramming_HW_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:NetworkProgramming_HW_1.View.ClientServer)NetworkProgramming_HW_1.View.ClientServer  5      @    :NetworkProgramming_HW_1.View.ClientServer.ClientServerView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:NetworkProgramming_HW_1.View.ClientServer     5      .��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      6   �� 5      $
��0.4* �6   6,    � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      6!   .+�5   
   �� -   5         ��Name$ serverMessageList��5   A   $��5,5,5,5q�6   $��0��6$   $��0��61   ��6\   �� *	ServerMsg+6�   �� 5   
   -   5         ��Name$ startServerButton��5   ?   $��5,5,5,5q�6   $��0��6"   $��1��6/   $��Start server��6Z   6�   �� 5   
   -   5        $ userMessageList��5   A   $��5,5,5,5q�6   $��1��6$   $��0��61   ��6Z   �� *	UserMsg+6|   �� 5   
   -   5        $ connectToServer��5   ?   $��5,5,5,5q�6   $��1��6"   $��1��6/   $��Connect to server��6X   6�   �� 5   
   -   5         ��Name$ userMessage��5   @   $��5,5,5,5q�6   $��2��6#   $��0��60   6W   �� 5   
   -   5        $ sendUserMessage��5   ?   $��5,5,5,5q�6   $��2��6"   $��1��6/   $
��Send��6X   6�   5      5      