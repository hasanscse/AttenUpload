AttenUploadWpf
Overview

AttenUploadWpf is a WPF desktop application built with .NET 8 (net8.0-windows) for automatically collecting employee attendance records from network-connected attendance machines and uploading them to a SQL Server database.

The application connects to configured attendance devices using their IP address and port, retrieves attendance logs, processes recent records, and uploads the data to the backend database.

Technology Stack
Framework: .NET 8
Target Framework: net8.0-windows
UI: Windows Presentation Foundation (WPF)
Language: C#
Database: Microsoft SQL Server
Device Communication: Attendance device SDK / ATTNLIB
Architecture: Windows Desktop Application
Key Features
Connects to multiple network attendance machines.
Retrieves attendance logs from configured devices.
Processes attendance records for the configured date range.
Uploads attendance data to SQL Server.
Retrieves machine IP addresses and ports from the database.
Automatically runs the upload process every 35 minutes.
Logs device connection status and upload results.
Handles device and database errors through application logging.
Application Workflow
Application starts.
Company code is retrieved from the database.
Configured attendance machines are loaded.
The application connects to each attendance machine.
Attendance logs are downloaded.
Recent attendance records are filtered.
Records are converted into a DataSet.
Attendance data is submitted to SQL Server.
Activity and errors are written to the application log.
The process repeats every 35 minutes.
Requirements
Windows 10/11 or compatible Windows environment
.NET 8 Desktop Runtime
SQL Server database
Network connectivity to attendance machines
ATTNLIB / required attendance-device SDK
Appropriate database permissions
Project Target
<TargetFramework>net8.0-windows</TargetFramework>

Configuration

Database connection strings and other environment-specific settings should be stored securely in configuration files, environment variables, or a secrets-management solution.

Do not commit database passwords or other sensitive credentials to Git.

Purpose

The application automates the synchronization of attendance data between physical attendance machines and the organization's central HR/attendance database, reducing the need for manual attendance-data collection and upload.
