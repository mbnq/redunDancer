# redunDancer

`redunDancer` is a network redundancy tool designed to automatically switch between two different network configurations in case of connectivity issues. 
The application allows the user to monitor network performance, configure IP settings, and manage network profiles through an easy-to-use graphical user interface.

![image](https://github.com/user-attachments/assets/7109d2f5-415c-4465-a1b9-d257d0775a9a)

## Key Features

- **Network Monitoring**: Continuously pings a specified IP address (e.g., a DNS server) to assess network stability.
- **Automatic Network Switching**: Switches between Network Setting A and Network Setting B if connectivity problems are detected based on a customizable retry count threshold.
- **Ping Log**: Maintains a detailed log of ping responses and failures. Logs can be saved for later review.
- **Network Configuration**: Supports manual configuration of IP addresses, subnet masks, and gateways for two different network profiles. Users can also set the program to use DHCP.
- **Tray Control**: Minimizes to the system tray for easy access. Includes options to show/hide the main interface and start/stop network monitoring.
- **Notifications**: Provides on-screen notifications for network events, such as switching network profiles or connectivity issues.

## Components

- **Network Configuration Panel**: Users can set up Network A and Network B profiles, including IP address, subnet mask, gateway, and DNS servers.
- **Ping Monitoring**: A background worker (`pingWorker`) continuously pings the designated addresses to monitor network health.
- **Settings Save and Load**: Network settings can be saved or loaded for quick configuration, and logs can be saved as `.txt` or `.log` files.
- **Tray Icon Functionality**: Control the application directly from the system tray, including starting or stopping monitoring and showing/hiding the main window.
- **Progress Indicators**: Visual indicators like progress bars to monitor ping response times and failed attempts.
- **Notifications Panel**: Displays fade-in/fade-out notifications for network-related events.

## Dependencies

- **.NET Framework**: Built using C# in Visual Studio 2022.
- **Windows Forms**: Utilizes the Windows Forms framework for the user interface.
  
## Usage

1. **Configure Network Settings**: Input IP addresses, subnet masks, and gateways for both Network A and Network B.
2. **Start Monitoring**: Click the "Run" button to begin monitoring network stability.
3. **Automatic Switching**: If the current network configuration becomes unstable, `redunDancer` will switch to the backup configuration automatically.
4. **Minimize to Tray**: The application can be minimized to the system tray to keep the desktop clean.
5. **View Logs**: Logs can be saved for detailed analysis of the network's behavior.

## Application Flow

- When the application starts, it checks if it is running with administrator privileges. If not, it restarts itself with elevated privileges.
- The application supports saving and loading configurations, allowing the user to quickly restore settings.
- In case of network instability, the program switches between profiles and provides visual notifications.

## Project Structure

- **Program.cs**: Entry point of the application, handling initial setup and administrative permissions.
- **mbRedunDancerMain** (Form Files): Handles the user interface, network configuration inputs, and the main application logic.
- **mbNet.cs**: Manages network-related operations such as pinging, detecting IP addresses, and configuring network adapters.
- **mbNotification.cs**: Defines the logic for notifications displayed to users when network settings change or issues arise.
- **mbTray.cs**: Implements the system tray functionality.
- **mbSaveLoad.cs**: Implements saving and loading of network settings.
- **mbControls.cs**: Handles user interactions, such as checkboxes, buttons, and manual switching of network settings.

## Contact

- Website: [mbnq.pl](https://mbnq.pl)
- Email: mbnq00 on Gmail
