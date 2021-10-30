# keizaBanner
stream banner (originally) for ~~memebirthday.net~~ memebig.net

this one *should* be easier to work with

# instructions
if you get any errors trying to run the app, you might need to install the <a href="https://www.microsoft.com/net/download/framework">latest version of the .NET Framework</a> (the framework only, not visual studio).

it expects to be in a folder with a file called "messages.txt" with all your messages separated by newlines.
it also expects there to be a "alerts" folder with all your streamlabs txt files in in the same directory.
in short, your folder hierarchy should look something like this:

* alerts
  * daily_top_donator.txt
  * monthly_top_donator.txt
  * etc
* keizaBanner.exe
* messages.txt

at present, apart from messages.txt, we're pulling in the following from streamlabs txt files:
- Daily Top Donor // session_top_donator.txt
- Monthly Top Donor // monthly_top_donator.txt
- Latest Sub // most_recent_subscriber.txt
- Latest Cheer // most_recent_cheerer.txt

# known issues/"issues"
- it'll display "~ good morning ~" as welcome text for the first 10 seconds before it opens anything
- it's a lot harder (i'm not sure it's actually possible without a major redesign) to have text look much different beyond font and size.
- everything (layout/looks-wise) is hardcoded right now to save my sanity.
- if you delete lines from messages.txt while running it might display wigglywoo text for 10s before it changes (this avoids a hard crash)
