AttenUploadWpf
Overview

AttenUploadWpf is a Windows desktop application built with .NET 8 WPF for automatically collecting employee attendance records from network-connected attendance machines and uploading them to a SQL Server database.

The application connects to configured attendance devices using their IP address and port, retrieves attendance logs, processes recent records, and uploads the data to the backend database.

Technology Stack
Framework: .NET 8
Target Framework: net8.0-windows
UI: Windows Presentation Foundation (WPF)
Language: C#
Database: Microsoft SQL Server
Device Communication: ATTNLIB / Attendance Device SDK
Features
Connects to multiple network attendance machines.
Retrieves attendance logs from configured devices.
Filters attendance records by date range.
Uploads attendance data to SQL Server.
Retrieves machine IP addresses and ports from the database.
Automatically runs the upload process every 35 minutes.
Logs device connection status and upload results.
Handles device and database errors.
Application Workflow
Application Start
       |
       v
Get Company Code
       |
       v
Get Attendance Machine Information
       |
       v
Connect to Attendance Device
       |
       v
Download Attendance Logs
       |
       v
Filter Recent Attendance Records
       |
       v
Create DataSet
       |
       v
Upload Data to SQL Server
       |
       v
Write Log
       |
       v
Wait 35 Minutes
       |
       +------> Repeat

Requirements
Windows 10/11
.NET 8 Desktop Runtime
SQL Server
Network access to attendance machines
Attendance device SDK / ATTNLIB
Required database permissions
Target Framework

The project targets:

<TargetFramework>net8.0-windows</TargetFramework>

Database

The application communicates with SQL Server through the following stored procedure:
