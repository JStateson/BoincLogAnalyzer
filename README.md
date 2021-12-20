# BoincLogAnalyzer - VS2019 Windows only
This app obtains the BOINC job log data files for analysis

Screen shot: https://stateson.net/bthistory/LogAnalyzerDemo.jpg

xAxis is 0..number of points

yAxis is time in seconds: CPU, Estimated, Elapsed

You can show all the data at once and a scroll bar can show more that is not on the screen

You can scroll the data "live" as if it is being collected.

The data file can be reviewed with notepad by double clicking the log filename

Things to be done

1 - Add filter such as plot only work unit names containing a phrase ie: "test"

2 - Want to show idle time where the log stopped and restarted

3 - Histogram of time distribution

Future possibilities requiring a BOINC client or manager change

1 - Show GPU time if the boinc client or manager logs GPU time

2 - Show GPU name and ID that processe the work unit (not logged by BOINC)
