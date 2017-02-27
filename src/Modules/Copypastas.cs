using Discord.Modules;

namespace Lithiumbot.Modules {
    internal partial class DinMammaModule : IModule {
        // Separated class to keep the copypastas from cluttering up main file.
        private static readonly string[] _copypasta = {
            @"▄█▀ █▬█ █ ▀█▀",
            @"Give a man a fire and he will be warm for a day, set a man on fire and he will be warm for the rest of his life",
            @"I'M DONGING YOU DADDY! ヽ(ಥ益ಥ;) ██]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]] 10% donged..... ████]]]]]]]]]]]]]]]]]]]]]]]]]]] 35% donged.... ███████]]]]]]]]]]]]]]]] 60% donged.... ███████████] 99% donged..... (° ͜ʖ͡°)╭∩╮ ERROR!(° ͜ʖ͡°)╭∩╮ ༼⌐□ل͜□༽True༼⌐□ل͜□༽ Daddies are undongable(~˘▾˘)~ I could never dong you daddy! (~˘▾˘)~ Send this to 10 other ༼⌐□ل͜□༽daddies༼⌐□ل͜□༽ who raise your ヽ༼ຈل͜ຈ༽ﾉdongerヽ༼ຈل͜ຈ༽ﾉ or never (つ°ヮ°)つ└⋃┘raise(つ°ヮ°)つ└⋃┘ again (° ͜ʖ͡°)╭∩╮(° ͜ʖ͡°)╭∩╮(⌐▀͡ ̯ʖ▀)(⌐▀͡ ̯ʖ▀)(° ͜ʖ͡°)╭∩╮(° ͜ʖ͡°)╭∩╮ If you get 0 back: no dongers for you ╰༼ཀДཀ༽╯╰༼ཀДཀ༽╯ 3 back: raise emヽ༼ຈل͜ຈ༽ﾉ 5 back: youre daddys donger (~˘▾˘)~(~˘▾˘)~ 10+ back: Daddy( つ◕ل͜◕)つ└⋃┘ง/͠-┌ل͜┐͡-\ง",
            @"ᕙ༼ຈل͜ຈ༽ᕗ THE LONGER THE DONGER THE STRONGER THE SHLONGER ᕙ༼ຈل͜ຈ༽ᕗ",
            @"(╯°□°)╯︵ ┻━┻ FLIP THAT TABLE.
┻━┻ ︵ ヽ(°□°ヽ) FLIP THIS TABLE.
┻━┻ ︵ ＼\('0')/／ ︵ ┻━┻ FLIP ALL THE TABLES
ಠ_ಠ bob...
ಠ_ಠ Put.
ಠ__ಠ The tables.
ಠ___ಠ Back.
(╮°-°)╮┳━┳
(╯°□°)╯︵ ┻━┻ NEVER",
            @"──────▄▌▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌
───▄▄██▌█ beep beep
▄▄▄▌▐██▌█ gay porn delivery
███████▌█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌
▀(@)▀▀▀▀▀▀▀(@)(@)▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀(@)▀",
            @" ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ༼ຈ ل͜ຈ༽ﾉ☂ ɪᴛs ʀᴀɪɴɪɴɢ sᴀʟᴛ! ヽ༼ຈل͜ຈ༽ﾉ☂ ヽ｀ヽ｀、ヽヽ｀ヽ｀、｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ、ヽヽ｀ヽ",
            @"( ͡ ͜ʖ ͡) happy donger
( ͝_ ͜S\ʖ͡) crappy donger
─=≡Σᕕ( ͡° ͜ʖ ͡°)ᕗ speedy donger
\($ ͜ʖ$)/ greedy donger
╰( ͡° ͜ʖ ͡° )つ──☆*:・ﾟ magic donger
( ͡° ʖ̯ ͡°) tragic donger
ᕙ( ͡° ͜ʖ ͡°)ᕗ no pain no gain
( ͡° ʖ̯ ͡°) ╾━╤デ╦︻ Kurt Cobain
",
            @" <:::::[]=¤༼ຈل͜ຈ༽ﾉ I am the knight of spamerino. Stand back foul moderino <:::::[]=¤༼ຈل͜ຈ༽ﾉ",
            @"A wild Booty has appeared!
........______
….. /'..........`\
.....(......)(......)
.....{..../....\....}
.....{.../......\...}
.....{..}........{..}
.....{..}........{..}
Watcha gonna do bout' it? ( ͡° ͜ʖ ͡°)
A) *Slap dat Booty*
B) No-scope it ( ͡° ͜ʖ ͡°)▄︻̷̿┻̿═━一
C) Feed it Doritos ▼ ◄ ▲ ► ▼
D) Run (Ya Pussy)",
            @"            │ ▓ 
╔══╗ ╔══╗ ▓▓ 
║▒▒║ ║▒▒║ ▓▓▓ 
║▒▒║ ║▒▓▓█▓ 
║▒▒║ ║▓█▓ 
║▒▒║ ║▒▒║ 
║▒▒║ ║▒▒║ Put this on the page of people who participated in 9/11",
            @"I'M DELETING YOU, MR CENA!😭👋🎺

██]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]] 10% complete.....

████]]]]]]]]]]]]]]]]]]]]]]]]]]] 35% complete....

███████]]]]]]]]]]]]]]]] 60% complete....

███████████] 99% complete..... 🚫ERROR!🚫 💯True💯 JOHN CENAS are irreplaceable 🎺I could never delete you Mr Cena!🎺 Send this to ten other 😎 Mr Cenas 😎 who give you 💪 DDTs 💪 Or never get called 👑 The Cenation Leader 👑 again❌❌😬😬❌❌ If you get 0 Back: you can't see me 🚫🚫👀 3 back: your time is now 🎺 ⏰ 5 back: your NAME IS JOHN CENA🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺🎺
",
            @"work it ᕙ༼ຈل͜ຈ༽ᕗ harder  
make it (ง •̀_•́)ง better  
do it ᕦ༼ຈل͜ຈ༽ᕤ faster  
raise ur ヽ༼ຈل͜ຈ༽ﾉ donger  ",
            @"╭━━━━━━━----------╮ 
┃　　● ══　                    |
┃██████████████┃ 
┃██████████████┃ 
┃██████████████┃ 
┃█ Come outside,  ███┃
┃█ I've got the           ██┃ 
┃█meme ( ͡° ͜ʖ ͡°)  ████ ┃ 
┃██████████████┃ 
┃██████████████┃ 
┃██████████████┃ 
┃　　　 ○　　　　　　┃ 
╰━━━━━━━----------╯",
            @"H͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍i็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็ t้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้้w̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒i͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍t้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็้็c͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍h็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็็!͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍͍̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒̒",
            @"ᕕ( ᐛ )╯╲___  Kappa  KappaClaus  KappaPride  Keepo Don't mind me just taking the Memes out for a walk",
            @"YOU HAVE BEEN VISITED BY...
████████████
████████████
████████████
████████████
████████████
████████████
████████████

THE GENERIC ASCII SPAM BLOCK 

NON- SPECIFIED GOOD THINGS WILL COME TO YOU

BUT ONLY IF YOU POST THIS ON 5 OTHER PROFILES
IF YOU DON'T SATAN WILL BURST INTO YOUR HOUSE AND RAPE YOUR FAMILY",
            @"༼ つ ◕_◕ ༽つAMENO༼ つ ◕_◕ ༽つ",
            @"░░░░░░░
░░YEE░░░░▄▄▄██▀▀▀▀███▄░░░░░
░░░░░░░▄▀▀░░░░░░░░░░░▀█░░░░
░░░░▄▄▀░░░░░░░░░░░░░░░▀█░░░
░░░█░░░░░▀▄░░▄▀░░░░░░░░█░░░
░░░▐██▄░░▀▄▀▀▄▀░░▄██▀░▐▌░░░
░░░█▀█░▀░░░▀▀░░░▀░█▀░░▐▌░░░
░░░█░░▀▐░░░░░░░░▌▀░░░░░█░░░
░░░█░░░░░░░░░░░░░░░░░░░█░░░
░░░░█░░▀▄░░░░▄▀░░░░░░░░█░░░
░░░░█░░░░░░░░░░░▄▄░░░░█░░░░
░░░░░█▀██▀▀▀▀██▀░░░░░░█░░░░
░░░░░█░░▀████▀░░░░░░░█░░░░░
░░░░░░█░░░░░░░░░░░░▄█░░░░░░
░░░░░░░██░░░░░█▄▄▀▀░█░░░░░░
░░░░░░░░▀▀█▀▀▀▀░░░░░░█░░░░░
░░░░░░░░░█░░░░░░░░░░░░█░░░░",
            @"┻┳|
┳┻|_
┻┳| •.•) Daddy,Are The Spammers Gone?
┳┻|⊂ﾉ
┻┳|
/﹋\
(҂`_´) -NOPE,SON GET BACK IN YOUR BEDROOM
<,︻╦╤─ ҉
/﹋\",
            @"You are about to get spammed with 600 dank memes. Prepare all nukes and weapons for the Great Spam War. If you can contain the amount of spam I have, you will be granted with special powers that allow you to smoke weed 200 times harder. Not only that, but you will have a laggy as fuck laptop. You know how lucky you are?????? My laptop runs at 669FPS and it never lags or is slow. YOU LUCKY SON OF A GUN. You will pay the price by me giving you a link (Which shall contain a download) which will wipe all your memory off the face of this universe and overwrite it with my own software, Memesoftlocker2.0000.0. You are so damn lucky you know that? NOT EVEN I HAVE IT SLUT. But if you were able to read up to this point congratulations, you suck. But click this link www.mymom.;;;;;;/eeeeeeee.crash; and you will be taken to a memory erase phrase. You lucky slut, but you will get the best computer software ever that makes your computer lag so bad that you can't even use it. LIKE HOW AMAZING??? Yes, I promise you this is 420% legit. But if you spread this abusive software you have EARNED I will suck you off this living universe so be careful buddy. Now, Please stop reading this message as it ends now...",
            @"Gr8 b8, m8. I rel8, str8 appreci8, and congratul8. I r8 this b8 an 8/8. Plz no h8, I'm str8 ir8. Cr8 more, can't w8. We should convers8, I won't ber8, my number is 8888888, ask for N8. No calls l8 or out of st8. If on a d8, ask K8 to loc8. Even with a full pl8, I always have time to communic8 so don't hesit8. dont forget to medit8 and particip8 and masturb8 to allevi8 your ability to tabul8 the f8. We should meet up m8 and convers8 on how we can cre8 more gr8 b8, I'm sure everyone would appreci8, no h8. I don't mean to defl8 your hopes, but its hard to dict8 where the b8 will rel8 and we may end up with out being appreci8d, I'm sure you can rel8. We can cre8 b8 like alexander the gr8, stretch posts longer than the Nile's str8s. We'll be the captains of b8, 4chan our first m8s the growth r8 will spread to reddit and like real est8 and be a flow r8 of gr8 b8, like a blind d8 we'll coll8, meet me upst8 where we can convers8, or ice sk8 or lose w8 infl8 our hot air baloons and fly, tail g8. We could land in Kuw8, eat a soup pl8 followed by a dessert pl8 the payment r8 won't be too ir8 and hopefully our currency won't defl8. We'll head to the Israeli-St8, taker over like Herod the gr8 and b8 the jewish masses, 8 million, m8. We could interrel8 communism, thought it's past it's maturity d8, a department of st8, volunteer st8. reduce the infant mortality r8, all in the name of making gr8 b8 m8.",
            @"_______( ͡° ͜ʖ ͡°)_▄︻̷̿┻̿═━一
███۞███████ ]▄▄▄▄▄▄▄▄▄▄▄▄▃
▂▄▅█████████▅▄▃▂
I███████████████████].
◥⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙◤
stop right there",
            @"͕͗𝔻͕͕͗͗𝕠͕͕͗͗𝕟͕͕͗͗'͕͕͗͗𝕥͕͗ ͕͗𝕥͕͕͗͗𝕒͕͕͗͗𝕝͕͕͗͗𝕜͕͗ ͕͗𝕥͕͕͗͗𝕠͕͗ ͕͗𝕞͕͕͗͗𝕖͕͗ ͕͗𝕠͕͕͗͗𝕣͕͗ ͕͗𝕞͕͕͗͗𝕪͕͗ ͕͗𝕤͕͕͗͗𝕠͕͕͗͗𝕟͕͗ ͕͗𝕖͕͕͗͗𝕧͕͕͗͗𝕖͕͕͗͗𝕣͕͗ ͕͗𝕒͕͕͗͗𝕘͕͕͗͗𝕒͕͕͗͗𝕚͕͕͗͗𝕟͕͗",
            @"🚨🚨💩❗OH SHI💩T 🚨🚨WE HAVE A👽DANK MEMER👽 HERE👇 A ROUND OF 👏APPLAUSE👏👏 FOR THE ✔APPROVED✔✅ MEME👀👀👀 CAUSE 👉THIS GUY👈 DESERVES👍👍 THE ⤴UPARROWS⤴⬆",
            @"░░░░██░░████████░░██░░░░░░░░░░░░░░░░░░░░░░░░ ░░██▒▒██▒▒▒▒▒▒▒▒██▒▒██░░░░░░░░░░░░░░░░░░░░░░ ░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░░░░░░░░░░░░░░░░░ ░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░░░░░░░░░░░░░░░ ██▒▒▒▒██▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██░░░░░░░░░░░░░░░░░░ ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████░░░░░░░░░░░░░░ ██▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████████████░░ ██▒▒██▒▒██▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██ ██▒▒▒▒████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████░░ ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░ ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░ ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░ ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░ ░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░░░░░░░ ░░██▒▒▒▒████▒▒▒▒████████▒▒▒▒████▒▒██░░░░░░░░ ░░██▒▒▒▒████▒▒██░░░░░░██▒▒██░░██▒▒██░░░░░░░░ ░░██▒▒██░░██▒▒██░░░░░░██▒▒██░░██▒▒██░░░░░░░░ ░░░░██░░░░░░██░░░░░░░░░░██░░░░░░██░░░░░░░░░░﻿",
            @"─────────────────────────▄▀▄  
─────────────────────────█─█  
─────────────────────────█─█  
─────────────────────────█─█  
─────────────────────────█─█  
─────────────────────────█─█  
─────────────────────────█─▀█▀█▄  
─────────────────────────█──█──█  
─────────────────────────█▄▄█──▀█  
────────────────────────▄█──▄█▄─▀█  
────────────────────────█─▄█─█─█─█  
────────────────────────█──█─█─█─█  
────────────────────────█──█─█─█─█  
────▄█▄──▄█▄────────────█──▀▀█─█─█  
──▄█████████────────────▀█───█─█▄▀  
─▄███████████────────────██──▀▀─█  
▄█████████████────────────█─────█  
██████████───▀▀█▄─────────▀█────█  
████████───▀▀▀──█──────────█────█  
██████───────██─▀█─────────█────█  
████──▄──────────▀█────────█────█ Look son!  
███──█──────▀▀█───▀█───────█────█ A Retard!  
███─▀─██──────█────▀█──────█────█  
███─────────────────▀█─────█────█  
███──────────────────█─────█────█  
███─────────────▄▀───█─────█────█  
████─────────▄▄██────█▄────█────█  
████────────██████────█────█────█  
█████────█──███████▀──█───▄█▄▄▄▄█  
██▀▀██────▀─██▄──▄█───█───█─────█  
██▄──────────██████───█───█─────█  
─██▄────────────▄▄────█───█─────█  
─███████─────────────▄█───█─────█  
──██████─────────────█───█▀─────█  
──▄███████▄─────────▄█──█▀──────█  
─▄█─────▄▀▀▀█───────█───█───────█  
▄█────────█──█────▄███▀▀▀▀──────█  
█──▄▀▀────────█──▄▀──█──────────█  
█────█─────────█─────█──────────█  
█────────▀█────█─────█─────────██  
█───────────────█──▄█▀─────────█  
█──────────██───█▀▀▀───────────█  
█───────────────█──────────────█  
█▄─────────────██──────────────█  
─█▄────────────█───────────────█  
──██▄────────▄███▀▀▀▀▀▄────────█  
─█▀─▀█▄────────▀█──────▀▄──────█  
─█────▀▀▀▀▄─────█────────▀─────█  
─█─────────▀▄──▀───────────────█  ",
            @"卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐
 Repost this windmill of friendship if you think 

     Europe should embrace racial diversity 
卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐 卐",
            @"Omg hai ___^ I’m anon-san and I absolutely luuuv @__@ anime <3 and my fav is naurto!!! Okies so anyways, im going to tell you about the BEST day of my life when I met my hot husband sasuke!! <333333333 OMFGZ HE WAS SOOOOO FREAKIN KAWAII IN PERSON!!! Supa kawaii desu!!!!!!!! ^___________________________________^
When I walked onto Tokyo street =____=I looked up and saw…SASUKE!!!!!!!!!!!!!!! <33333333333333333333333333333333333333333333333333333333333333!!!! “ KONNICHIWA OMGZZZZZZZZZZZZZZZZ SUPA SUPA SUPA KAWAII SASUKE-SAMA!!!!!” I yelled n____n then he turned chibi then un-chibi!! he looked at me [O.O;;;;;;;;;;;] and then he saw how hot I am *___* he grabbed my hand and winked ~_^ then pulled me behind a pocky shop o_o and started to kiss me!!!!!! [OMG!!! HIS TOUNGE TASTED LIKE RAMEN!!! RLY!! >.> <.< >.< (O) (O) (O)] then I saw some baka fat bitch watching us and I could tell she was undressing him with her eyes!!!!!!! [ -___________-;;;;; OMG I COULDN’T BELIEVE IT EITHER!!! (ò_ó) (ò_ó) (ò_ó)] so I yelled “UH UH BAKA NEKO THAT’S MY MAN WHY DON’T YOU GO HOOK UP WITH NARUTO CAUSE SASUKE-SAMA LOVES ME!!! (ò_ó)” then sasuke held me close =^= and said he would only ever love me and kissed me again!!!!!!! ** (O)/ then we went to his apartment and banged all night long and made 42 babies and they all became ninjas!!!!!!!!!!!!!!! Nyaaaaa!!! (^___<) ^______________;;;;;;;;;;;;;;;;",
            @"What's my gender? 🚺🚹❓❓Did you just 😱 ask me 😂😂 what my gender 👧🏽👦🏽 was❓❗️Oh my god, you are LITERALLY 👋🏻 the most IGNORANT 💩 AND ILLTERATE 📚📚📚 ❌❌ FUCK I have EVER seen👀👀👀 browsing before 😂😂😂😂😂 What gives you the RIGHT ✔️✔️ to ask me what my 🚺🚹🚺🚹 gender is? 😂😂😂 MHMM? NOTHING ❌❌ THATS WHAT ❗️❗️❗️❗️❗️❗️❗️❗️❗️Since you're SOOOOOOO curious🙇🏼🙇🏼🙇🏼🙇🏼 I'll have you know ☝🏼☝🏼☝🏼☝🏼 that I am a 🚺🚹 G E N D E R F L U I D 🚹🚺 I'm not gonna sit here ⬇️⬇️ and explain 📢📢 what that is to someone as IGNORANT 😂💩💩 as you, but I'm gonna tell you anyways ☝🏼️🙇🏼☝🏼🙇🏼☝🏼🙇🏼 Being G 🚺 E 🚹 N 🚺 D 🚹 E 🚺 R 🚹 F 🚺 L 🚹 U 🚺 I 🚹 D means that I am both M A L E 🍆💦👦🏽 (cis scum😷😷😷😷😷) and F E M A L E👧🏽👠💄🍑 ❗️❗️❗️❗️ I can swap ⬇️⬆️➡️⬅️ between these genders 👌🏻😂 as I please❗️❗️❗️❗️❗️❗️❗️ You're ignorance 😷 is literally OOZING 💦💦💦💦 out 😂😂😷😷😂😷😂😂﻿GERMER ",
            @"( ͡° ͜ʖ ͡°)                ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)             ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)         ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)     ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)     ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)         ( ͡° ͜ʖ ͡°)
( ͡° ͜ʖ ͡°)             ( ͡° ͜ʖ ͡°)


( ͡° ͜ʖ ͡°)                     ( ͡° ͜ʖ ͡°)
  ( ͡° ͜ʖ ͡°)                 ( ͡° ͜ʖ ͡°)
      ( ͡° ͜ʖ ͡°)         ( ͡° ͜ʖ ͡°)
           ( ͡° ͜ʖ ͡°)( ͡° ͜ʖ ͡°)
                ( ͡° ͜ʖ ͡°)
                ( ͡° ͜ʖ ͡°)
                ( ͡° ͜ʖ ͡°)
                ( ͡° ͜ʖ ͡°)


                    ( ͡° ͜ʖ ͡°)
            ( ͡° ͜ʖ ͡°)    ( ͡° ͜ʖ ͡°)
      ( ͡° ͜ʖ ͡°)               ( ͡° ͜ʖ ͡°)
  ( ͡° ͜ʖ ͡°)
      ( ͡° ͜ʖ ͡°)
          ( ͡° ͜ʖ ͡°)( ͡° ͜ʖ ͡°)
                           ( ͡° ͜ʖ ͡°)
                                 ( ͡° ͜ʖ ͡°)
 ( ͡° ͜ʖ ͡°)                  ( ͡° ͜ʖ ͡°)
     ( ͡° ͜ʖ ͡°)          ( ͡° ͜ʖ ͡°)
         ( ͡° ͜ʖ ͡°)( ͡° ͜ʖ ͡°)﻿",
            @"My name is Jafar
I come from afar
There's a bomb in my car
Allahu Akbar",
            @"( ͡° ͜ʖ ͡°) Every 60 seconds in Africa, a minute passes. Together we can stop this. Please spread the word ( ͡° ͜ʖ ͡°) ",
            @"( ͡° ͜ʖ ͡°)╯╲___卐卐卐卐 Don't mind me just taking the mods out for a walk﻿",
            @"ζ༼⊙ ͟ل͜ ⊙༽ᶘ ᴀʀᴇ ᴡᴇ ʜᴜᴍᴀɴ ᴏʀ ᴀʀᴇ ᴡᴇ Cᴀɴᴄᴇʀ? ζ༼⊙ ͟ل͜ ⊙༽ᶘ",
            @"By the Nine Divines! What did you just say about me, you criminal scum? I'll have you know I graduated top of my class in the Arcane University, and I've been known to cast one hell of a fireball, and I have over 300 confirmed summons. I am trained in daedric warfare and I'm the swords master of the entire Imperial forces. You are nothing to me but just another target. I will make you beg to Akatosh as I bend you over like a common whelp, mark my words, on my oath as the Champion of Cyrodiil. You think you can come into my mind through this magic device and insult me? Think again, scum. As we speak I have every assassin and thief across all of Tamriel looking for your initial position so you better prepare for the storm atronach, you goblin. The storm atronach that wipes out the pathetic little husk you call your life. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my unarmed skill! Not only am I extensively trained in archery and horseback riding, but I have access to the entire congregation of the Thieves Guild, Dark Brotherhood, Mages Guild, and untold hordes of Daedric warriors, and I will use every one of them to banish you to the plane of Oblivion. If only you could have had the clairvoyance to see what divine retribution your little 'clever' runes were about to bring down upon you, maybe you would have held your tongue you dark skin. But you couldn't, you didn't, and now you're paying the price, you goddamn idiot. I will become the embodiment of Mehrunes Dagon, and open a portal to Oblivion the likes of which you have never seen. You're fucking dead, law breaker.",
            @"What in the name of Talos did you just say to me, you milk drinker? I'll have you know I am the Dragonborn, and I've been on numerous raids on dragons and I have over 300 dragon souls. I am trained in the Thu'um and I'm the top archer in the entire Imperial Legion. You are nothing to me but just another enemy. I will kill you with arrows the likes of which has never been seen before on Nirn, mark my words. You think you can just say that to me over the webs created by the Dwemer? Think again, milk drinker. As we speak I am contacting my Dark Brotherhood assassins across Tamriel and your hold is being traced right now so you better prepare for the Call Storm shout, milk drinker. The storm that wipes out the pathetic little thing you call Mundus. You are going to be sent to Aetherius, milk drinker. I can be at any hold, any time, and can kill you in over seven hundred ways, and that's just with my voice. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the Imperial Legion and I will use it to its full extent to wipe your miserable ass off the face of Mundus, you milk drinker. If only you could have known what unholy retribution your little 'clever' opinionated statement was about to bring down upon you, maybe you would have held your tongue. But you couldn't, you didn't, and now you're paying the price, you fool. I will shout fury all over you and you will drown in it. You're dead, milk drinker.",
            @"What the fuck did you just fucking say about me, you little milk drinker? I’ll have you know I graduated top of my class in the Mage's College of Winterhold, and I’ve been involved in numerous secret raids on the Stormcloaks, and I have over 300 confirmed Dragon souls absorbed. I am trained in hand-to-hand and magic combat, and I’m the top swordsman in the entire Imperial Legion. You are nothing to me but just another N'wah. I will wipe you the fuck out with pure brute force the likes of which has never been seen before on Nirn, mark my fucking words. You think you can get away with saying that shit to me? Think again, fetcher. As we speak I am contacting my secret network of Dark Brotherhood assassins across the whole of Tamriel and your presence is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the Empire of Cyrodiil and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little s'wit. If only you could have known what unholy retribution your little 'clever' comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury and Thu'um all over you and you will drown in it. You'll make a fine rug, cat!",
            @"What the fuck did you just fucking say about me, you little bitch? I’ll have you know I graduated top of my class in the White Lotus Avatar Training Academy, and I’ve been involved in numerous secret raids on the Equalists, and I have over 300 confirmed Probending wins. I am trained in goat-gorrila warfare and I’m the top bender in the entire United Republic forces. You are nothing to me but just another target. I will bend you the fuck out with precision the likes of which has never been seen before on the physical or Spirit World, mark my fucking words. You think you can get away with saying that shit to me over the Spirit Vines? Think again, fucker. As we speak I am contacting my secret network of spies across the Spirit World and your radio signal is being traced right now so you better prepare for the storm, maggot-fly. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just without bending. Not only am I extensively trained in unarmed combat, but I have access to every element and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will bend shit all over you and you will drown in it. You’re fucking dead, kiddo, and you've gotta deal with it.",
            @"What filth dared pass your unworthy lips, pitiful urchin? I will declare, am the heir of the Elders, I have led our people out of tragedy single-handed, and I have destroyed over 300 white demons. I am learned in the arts of the earth and sky, and none are more connected to the Great Spirit than I! You are but nothing to me, prey. I will have your head hollowed for a gourde, my word is sacred! Do you think your magic will allow you to continue to disrespect me like this? Think again, dog! Even as you stand, my brothers from across the land are circling your home and your sacred place is being hunted right now, so prepare for the onslaught, rat. The onslaught that will decimate your very way of life from your people's history. You are a breathing ghost, child. I can move as I please, night or day, and I can steal your breath in over seven hundred ways, without so much as a knife. Not only am I a warrior-king's son, but I have the loyalty of my entire tribe and I will rather laugh than hesitate at wiping your hide out of this world, little dog. If only you had known what torrents your gibberish would bring upon, you would have kept silent. But you could not, you did not, and now the price will be yours to pay, backwards fool. I will spread fury like droppings until it consumes you, and you drown in its depths. You are a memory, boy.",
            @"What the fuck did you just fucking say about my gear, you little n00b? I’ll have you know I am a lvl 90 Undead Arcane Mage, and I’ve won so many PVP matches, and I have done raids on every 10 man heroic dungeon. I also have a fuckton of macros and I have a GS of 10K. You are nothing to me but just a lvl 12 gnome hunter. I will pwn the fuck out of you with Arcane Missiles the likes of which has never been seen before on Azeroth AND Outland, mark my fucking words. You think you can get away with saying that shit to me over raid? Think again, fucker. As we speak I am contacting my guild of mages and shamans across The Eastern Kingdoms and your character is being targeted right now so you better prepare for the ownage, n00b. The Arcane Barrage that wipes out the pathetic little thing you call your character. You’re fucking pwn’d, n00b. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my secondary talent tree. Not only am I extensively trained in Arcane magic, but I have access to the entire arsenal of Fire magic and I will use it to its full extent to wipe your miserable neckbeard off the face of Azeroth, you little faggot. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re getting debuffed, you goddamnn00b. I will shit Dragon’s Breath all over you and you will burn in it. You’re fucking pwn’d, faggot.",
            @"What the ( ͡° ͜ʖ ͡°) did you just ( ͡° ͜ʖ ͡°) say about me, you little ( ͡° ͜ʖ ͡°)? I'll have you know I graduated top of my ( ͡° ͜ʖ ͡°) in the ( ͡° ͜ʖ ͡°), and I've been involved in numerous secret ( ͡° ͜ʖ ͡°) on ( ͡° ͜ʖ ͡°), and I have over 300 confirmed ( ͡° ͜ʖ ͡°). I am trained in ( ͡° ͜ʖ ͡°) warfare and I'm the top ( ͡° ͜ʖ ͡°) in the entire US armed ( ͡° ͜ʖ ͡°). You are nothing to me but just another ( ͡° ͜ʖ ͡°). I will wipe you the ( ͡° ͜ʖ ͡°) out with precision the ( ͡° ͜ʖ ͡°) of which has never been seen before on this ( ͡° ͜ʖ ͡°), mark my ( ͡° ͜ʖ ͡°) words. ( ͡° ͜ʖ ͡°) think ( ͡° ͜ʖ ͡°) can get away with saying that ( ͡° ͜ʖ ͡°) to me over the ( ͡° ͜ʖ ͡°)? Think again, ( ͡° ͜ʖ ͡°). As we speak I am contacting my secret network of ( ͡° ͜ʖ ͡°) across the ( ͡° ͜ʖ ͡°) and your ( ͡° ͜ʖ ͡°) is being ( ͡° ͜ʖ ͡°) right now so you better ( ͡° ͜ʖ ͡°) for the ( ͡° ͜ʖ ͡°), ( ͡° ͜ʖ ͡°). The ( ͡° ͜ʖ ͡°) that wipes out the pathetic little thing you call ( ͡° ͜ʖ ͡°). You're ( ͡° ͜ʖ ͡°) dead, ( ͡° ͜ʖ ͡°). I can be ( ͡° ͜ʖ ͡°), anytime, and I can ( ͡° ͜ʖ ͡°) you in over seven hundred ( ͡° ͜ʖ ͡°), and that's just with my bare ( ͡° ͜ʖ ͡°). Not only am I extensively trained in ( ͡° ͜ʖ ͡°) combat, but I have access to the entire ( ͡° ͜ʖ ͡°) of the United States ( ͡° ͜ʖ ͡°) and I will use it to its full extent to wipe your miserable ( ͡° ͜ʖ ͡°) off the face of the ( ͡° ͜ʖ ͡°), you little ( ͡° ͜ʖ ͡°). If only you could have known what unholy retribution your little ( ͡° ͜ʖ ͡°) comment was about to bring down upon ( ͡° ͜ʖ ͡°), maybe you would have held your ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°). But you couldn't, you didn't, and now you're paying the price, you ( ͡° ͜ʖ ͡°). I will ( ͡° ͜ʖ ͡°) fury all over ( ͡° ͜ʖ ͡°) and ( ͡° ͜ʖ ͡°) will ( ͡° ͜ʖ ͡°) in it. You're ( ͡° ͜ʖ ͡°) dead, ( ͡° ͜ʖ ͡°).",
            @"What in Davy Jones' locker did ye just bark at me, ye scurvy bilgerat? I'll have ye know I be the meanest cutthroat on the seven seas, and I've led numerous raids on fishing villages, and raped over 300 wenches. I be trained in hit-and-run pillaging and be the deadliest with a pistol of all the captains on the high seas. Ye be nothing to me but another source o' swag. I'll have yer guts for garters and keel haul ye like never been done before, hear me true. You think ye can hide behind your newfangled computing device? Think twice on that, scallywag. As we parley I be contacting my secret network o' pirates across the sea and yer port is being tracked right now so ye better prepare for the typhoon, weevil. The kind o' monsoon that'll wipe ye off the map. You're sharkbait, fool. I can sail anywhere, in any waters, and can kill ye in o'er seven hundred ways, and that be just with me hook and fist. Not only do I be top o' the line with a cutlass, but I have an entire pirate fleet at my beck and call and I'll damned sure use it all to wipe yer arse off o' the world, ye dog. If only ye had had the foresight to know what devilish wrath your jibe was about to incur, ye might have belayed the comment. But ye couldn't, ye didn't, and now ye'll pay the ultimate toll, you buffoon. I'll shit fury all over ye and ye'll drown in the depths o' it. You're fish food now, lad.",
            @"What dost thou just exclaim to thyself, you meager wench? I’ll have thou know I graduated valedictorian at Cambridge University, and thy hath partaken in numerous invasions of France, and thyself have over 300 recorded slayings. Thyself hath been trained in chivalrous warfare and thyself am the top Longbowman in the entire King of England’s army. Thou art not a thing but target to thyself. Thy will conquer thou with accuracy the likes of which hath never been witnessed before upon this fair isle, dwell upon my oration. Thou think thou can get away with proclaiming such filth to thyself via His Majesty’s letter deliverance service? Repeat your thoughts, copulator. As we engage in conversation thyself art summoning thy clandestine company of shadowy individuals across His Majesty’s kingdom and thou fortress doth be traced this day so thou best prepare for the ruckus, peasant. The ruckus that decimates the pathetic meager object thou proclaim thou vitae. Thou be mortem, child. Thy can roam any county, any sunrise to sunset, and thy can take thou life in above 700 technques, and that’s using naught but thy own gauntlets. Not exclusively is thy extensively trained in duelling without a blade, but thy pertain access to the entire arsenal of the His Majesty’s Royal Cavalry and thy will use it to its complete usefulness to wipe thou forlorn buttocks off the face of the kingdom, thou meager dropping. If only thou could hath foreseen the divine retribution thou meager “quick-witted” exclamation would in due time bringeth upon thou, perhaps thou would hath halted thou tongue. Thou could not, thou did not, and thou art paying the blasted bounty, thou God forsaken imbicile. Thy shall excrete fury upon thou and thou will suffocate on said fury. Thou be vanquished, child.",
            @"What the desu did you just fucking desu about me, you little desu? I’ll have you know I graduated top of my desu in the Navy Desus, and I’ve been involved in numerous secret desus on Al-Desu, and I have over 300 confirmed desus. I am trained in desu warfare and I’m the top desu in the entire US armed desu. You are nothing to me but just another desu. I will desu you the fuck out with desu the likes of which has never been seen before on this desu, mark my fucking desu. You think you can get away with saying that desu to me over the desu? Think again, desu. As we speak I am contacting my secret network of desu across the USA and your desu is being traced right now so you better prepare for the spam, maggot. The spam that wipes out the pathetic little thing you call your desu. You’re fucking desu, kid. I can be desu, desu, and I can desu you in over desu ways, and that’s just with my bare desu. Not only am I extensively trained in unarmed desu, but I have access to the entire arsenal of the United States Desu and I will use it to its full extent to wipe your miserable desu off the face of the desu, you little desu. If only you could have known what unholy desu your little “desu” comment was about to bring down upon you, maybe you would have held your fucking desu. But you desu, you desu, and now you’re desu, you goddamn desu. I will shit desu all over you and you will drown in it. You’re fucking desu, kiddo.",
            @"What the scooby-dooby-do did you just say about me, you little scooby snack? I’ll have you know I graduated top of my class in The Mystery Gang, and I’ve been involved in numerous secret investigations in America, and I have over 300 confirmed fake supernatural villains uncovered. I am trained in shit-pants warfare and I’m the top pussy in the entire US supernatural investigation committee. You are nothing to me but just another phony. I will uncover your fake supernatural disguise with precision the likes of which has never been seen before on this Earth, mark my words. You think you can get away with trying to scare people around me? Think again. As we speak I am contacting my secret network of ghosts across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out your Halloween costume closet and gives me all your scooby snacks. Your tricks are mine, kid. I can be anywhere, anytime, and I can stop you scaring people in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in solving mysteries, but I have access to the entire arsenal of the Ghost Busters’ HQ and I will use it to its full extent to wipe your entire horror-inducing gags. If only you could have known what unholy retribution of trying to scare people and trying to frighten me would bring you, maybe you would have not of dressed up as a ghost at all. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over your malevolent goals and you will watch me in your pathetic ghost suit as you’re taken away in a police van. Your pranks are over, kiddo.",
            @"Tᴏ ᴘʀᴏᴛᴇᴄᴛ ᴛʜᴇ ᴄʜᴀᴛ ғʀᴏᴍ ᴅᴇᴠᴀsᴛᴀᴛɪᴏɴ. ᴛᴏ ᴜɴɪᴛᴇ ᴀʟʟ sᴘᴀᴍᴍᴇʀs ᴡɪᴛʜɪɴ ᴏᴜʀ ɴᴀᴛɪᴏɴ. ᴛᴏ ᴅᴇɴᴏᴜɴᴄᴇ ᴛʜᴇ ᴇᴠɪʟ ᴏғ Tʀᴜᴍᴘ ᴀɴᴅ ᴍᴏᴅs. ᴛᴏ ᴇxᴛᴇɴᴅ ᴏᴜʀ sᴘᴀᴍ ᴛᴏ ᴛʜᴇ sᴛᴀʀs ᴀʙᴏᴠᴇ. ᴄᴏᴘʏ! ᴘᴀsᴛᴇ! ᴄʜᴀᴛ sᴘᴀᴍ ʙʟᴀsᴛ ᴏғғ ᴀᴛ ᴛʜᴇ sᴘᴇᴇᴅ ᴏғ ʟɪɢʜᴛ! sᴜʀʀᴇɴᴅᴇʀ ᴍᴏᴅs ᴏʀ ᴘʀᴇᴘᴀʀᴇ ᴛᴏ ғɪɢʜᴛ. ",
            @"☐ Not REKT ☑ REKT ☑ REKTangle ☑ SHREKT ☑ REKT-it Ralph ☑ Total REKTall ☑ The Lord of the REKT ☑ The Usual SusREKTs ☑ North by NorthREKT ☑ REKT to the Future ☑ Once Upon a Time in the REKT ☑ The Good, the Bad, and the REKT ☑ LawREKT of Arabia ☑ Tyrannosaurus REKT ☑ eREKTile dysfunction",
            @" (̿▀̿ ̿Ĺ̯̿̿▀̿ ̿)̄ ɴᴀᴍᴇ's ᴅᴏɴɢ. ᴊᴀᴍᴇs ᴅᴏɴɢ (̿▀̿ ̿Ĺ̯̿̿▀̿ ̿)̄",
            @"༼ ºل͟º༼ ºل͟º༽ºل͟º ༽ YOU COPERINO FRAPPUCCIONO PASTARINO'D THE WRONG DONGERINO ༼ ºل͟º༼ ºل͟º༽ºل͟º ༽",
            @"( ͡° ͜ʖ ͡° )つ──☆*:・ﾟ clickty clack clickty clack with this chant I summon spam to the chat ( ͡° ͜ʖ ͡° )つ──☆*:・ﾟ",
            @"(ง ͠° ل͜ °)ง LET ME DEMONSTRATE DONGER DIPLOMACY (ง ͠° ل͜ °)ง",
            @"ヽ༼ຈل͜ຈ༽ง MY RIGHT DONG IS ALOT STRONGER THAN MY LEFT ONE ヽ༼ຈل͜ຈ༽ง",
            @"I sexually Identify as a minion. Ever since I was a boy I dreamed of walking down the lanes of Summoners Rift just to get slaughtered instantly. People say to me that a person being a minion is Impossible and I’m fucking retarded but I don’t care, I’m beautiful. I’m having a plastic surgeon install a little stone helmet, shield and battle hammer on my body. From now on I want you guys to call me “blue melee creep” and respect my right to willingly suicide into powerful enemy champions. If you can’t accept me you’re a miniophobe and need to check your summoning privilege. Thank you for being so understanding.",
            @"I sexually Identify as a ghost pirate. Ever since I was a boy I dreamed of sailing the undead seas searching for the afterlife of dave jones’ locker . People say to me that a person being a ectoplasmic-sea captain is Impossible and I’m fucking retarded but I don’t care, I’m sp00ky. I’m having an ethereal cutlass created, a 17th century french sloop and a ghostly crew of shanty singers bought. From now on I want you guys to call me “deadbeard” and respect my right to kill rival poltergeist and photonically phase my being into the next realm . If you can’t accept me you’re a phantom-buccaneerphobe and need to check your undead-aquatic privilege. Thank you for being so understanding matey.",
            @"I sexually identify as a single, Pringle, ready to mingle. Ever since I was a potato I dreamed of being thin sliced, covered in disgusting oil then heated in a medium oven until reaching climax at the micro second of golden-browness. People bully me, and say things like “what the fuck, you aren’t a Pringle”, but I know deep down they are just jealous of my inner beauty. I have already started hiding in cylinders all day, and now im improving my crunchiness by regularly burning my sides on the stove. I want you guys to respect my natural ability to instantly satisfy low salt carb cravings, and if you don’t you are oppressing me, and you should check your diabetes type. Thank you for being so understanding.",
            @"I sexually Identify as a Racecar. Ever since I was a boy I dreamed of drifting around corners and running quarter miles in under ten seconds. People say to me that a person being a Racecar is Impossible and I’m fucking retarded but I don’t care, I’m beautiful. I’m having a shop mechanic install 100-shot of nitrous, adjustable coilovers, and twin scroll turbos on my chassis. From now on I want you guys to call me “Drift King” and respect my right to burn rubber below and shoot flames needlessly. If you can’t accept me you’re a ricer and need to check your modifying privilege. Thank you for being so understanding.",
            @"I sexually Identify as a meme. Ever since I was a boy I dreamed of being uploaded onto the imgur website and linked into the reddit threads. People say to me that a person being a meme is Impossible and I’m fucking retarded but I don’t care, I’m beautiful. I’m having a computer scientist put my brain into my computer like johnny depp in transendence, equipping me with the dankest of pictures from the internet. From now on I want you guys to call me “Sir Danks-a-lot” and respect my right to meme from above and meme needlessly. If you can’t accept me you’re a memephobe and need to check your internet privilege. Thank you for being so understanding.",
            @"I sexually Identify as an Attack Helicopter. Ever since I was a boy I dreamed of soaring over the oilfields dropping hot sticky loads on disgusting foreigners. People say to me that a person being a helicopter is Impossible and I'm fucking retarded but I don't care, I'm beautiful. I'm having a plastic surgeon install rotary blades, 30 mm cannons and AMG-114 Hellfire missiles on my body. From now on I want you guys to call me 'Apache' and respect my right to kill from above and kill needlessly. If you can't accept me you're a heliphobe and need to check your vehicle privilege. Thank you for being so understanding.",
            @"You know what I don't understand? No one ever takes copypastas seriously. I'm being honest here. No one ever stops and really understands the copypastas. They just pass it off as just another shitpost that was made by some edgy shit in his basement, waiting for downvotes and hate comments. These people are wrong. copypastas are made by the greatest minds on the planet. Each one is carefully and delicately crafted to get the least amount of karma on Reddit. I'm led to believe that maybe even Ernest Hemingway made a copypasta. Now, I am not talking about the shitty twitter copypastas that don't take any effort at all, like what you see on say, for example, Berny Snaders' page. They lack a soul. I ony speak of 4Chan copypastas and the like. Copypastas that make fun of the saltiness of OP and call his post cancer. These types of copypastas deserve respect. They aren't trash. They are literature. ",
            @"I sexually Identify as a bot. Ever since I was a boy I dreamed of soaring over the chat dropping shitposts and views on disgusting streamers. People say to me that a person being a bot is Impossible and I'm fucking retarded but I don't care, I'm beautiful. I'm having a plastic surgeon install keyboards, hard drives and mobile access points on my body. From now on I want you guys to call me 'Marvin' and respect my right to shitpost from above and shitpost needlessly. If you can't accept me you're a botophobe and need to check your digital privilege. Thank you for being so understanding.",
            @"I sexually Identify as Soldier 76. Ever since I was a boy I dreamed of sprinting around using aimbot to gun people down, screaming 'TANGO DOWN' into my mic after every collateral. People say to me that being Soldier 76 is Impossible and I’m fucking retarded but I don’t care, I’m beautiful. I’m having a plastic surgeon install an augmented reality visor into my face, and Lockheed Martin design and build me a heavy pulse rifle with triple 70mm helix rocket clusters. From now on I want you guys to call me “John 'Jack' Morrison” and respect my right to kill and kill needlessly. If you can’t accept me you’re a soldierphobe and need to check your soldier privilege. Thank you for being so understanding.",
            @"What the desu did you just fucking desu about me, you little desu? I'll have you know I graduated top of my desu in the Navy Desus, and I've been involved in numerous secret desus on Al-Desu, and I have over 300 confirmed desus. I am trained in desu warfare and I'm the top desu in the entire US armed desu. You are nothing to me but just another desu. I will desu you the fuck out with desu the likes of which has never been seen before on this desu, mark my fucking desu. You think you can get away with saying that desu to me over the desu? Think again, desu. As we speak I am contacting my secret network of desu across the USA and your desu is being traced right now so you better prepare for the spam, maggot. The spam that wipes out the pathetic little thing you call your desu. You're fucking desu, kid. I can be desu, desu, and I can desu you in over desu ways, and that's just with my bare desu. Not only am I extensively trained in unarmed desu, but I have access to the entire arsenal of the United States Desu and I will use it to its full extent to wipe your miserable desu off the face of the desu, you little desu. If only you could have known what unholy desu your little 'desu' comment was about to bring down upon you, maybe you would have held your fucking desu. But you desu, you desu, and now you're desu, you goddamn desu. I will shit desu all over you and you will drown in it. You're fucking desu, kiddo.",
            @"Gr8 b8, m8. I rel8, str8 appreci8, and congratul8. I r8 this b8 an 8/8. Plz no h8, I’m str8 ir8. Cre8 more, can’t w8. We should convers8, I won’t ber8, my number is 8888888, ask for N8. No calls l8 or out of st8. If on a d8, ask K8 to loc8. Even with a full pl8, I always have time to communic8 so don’t hesit8",
            @"UPLOADING VIRUS.EXE ████████████████] 99%",
            @"
░░░░░░░░░░░░░░░░░░░░ 
░▄▀▄▀▀▀▀▄▀▄░░░░░░░░░
░█░░░░░░░░▀▄░░░░░░▄░
█░░▀░░▀░░░░░▀▄▄░░█░█
█░▄░█▀░▄░░░░░░░▀▀░░█
█░░▀▀▀▀░░░░░░░░░░░░█
█░░░░░░░░░░░░░░░░░░█
█░░░░░░░░░░░░░░░░░░█
░█░░▄▄░░▄▄▄▄░░▄▄░░█░
░█░▄▀█░▄▀░░█░▄▀█░▄▀░
░░▀░░░▀░░░░░▀░░░▀░░░
The dog absorbs the memes",
            @"What the ( ͡° ͜ʖ ͡°) did you just ( ͡° ͜ʖ ͡°) say about me, you little ( ͡° ͜ʖ ͡°)? I'll have you know I graduated top of my ( ͡° ͜ʖ ͡°) in the ( ͡° ͜ʖ ͡°), and I've been involved in numerous secret ( ͡° ͜ʖ ͡°) on ( ͡° ͜ʖ ͡°), and I have over 300 confirmed ( ͡° ͜ʖ ͡°). I am trained in ( ͡° ͜ʖ ͡°) warfare and I'm the top ( ͡° ͜ʖ ͡°) in the entire US armed ( ͡° ͜ʖ ͡°). You are nothing to me but just another ( ͡° ͜ʖ ͡°). I will wipe you the ( ͡° ͜ʖ ͡°) out with precision the ( ͡° ͜ʖ ͡°) of which has never been seen before on this ( ͡° ͜ʖ ͡°), mark my ( ͡° ͜ʖ ͡°) words. ( ͡° ͜ʖ ͡°) think ( ͡° ͜ʖ ͡°) can get away with saying that ( ͡° ͜ʖ ͡°) to me over the ( ͡° ͜ʖ ͡°)? Think again, ( ͡° ͜ʖ ͡°). As we speak I am contacting my secret network of ( ͡° ͜ʖ ͡°) across the ( ͡° ͜ʖ ͡°) and your ( ͡° ͜ʖ ͡°) is being ( ͡° ͜ʖ ͡°) right now so you better ( ͡° ͜ʖ ͡°) for the ( ͡° ͜ʖ ͡°), ( ͡° ͜ʖ ͡°). The ( ͡° ͜ʖ ͡°) that wipes out the pathetic little thing you call ( ͡° ͜ʖ ͡°). You're ( ͡° ͜ʖ ͡°) dead, ( ͡° ͜ʖ ͡°). I can be ( ͡° ͜ʖ ͡°), anytime, and I can ( ͡° ͜ʖ ͡°) you in over seven hundred ( ͡° ͜ʖ ͡°), and that's just with my bare ( ͡° ͜ʖ ͡°). Not only am I extensively trained in ( ͡° ͜ʖ ͡°) combat, but I have access to the entire ( ͡° ͜ʖ ͡°) of the United States ( ͡° ͜ʖ ͡°) and I will use it to its full extent to wipe your miserable ( ͡° ͜ʖ ͡°) off the face of the ( ͡° ͜ʖ ͡°), you little ( ͡° ͜ʖ ͡°). If only you could have known what unholy retribution your little ( ͡° ͜ʖ ͡°) comment was about to bring down upon ( ͡° ͜ʖ ͡°), maybe you would have held your ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°). But you couldn't, you didn't, and now you're paying the price, you ( ͡° ͜ʖ ͡°). I will ( ͡° ͜ʖ ͡°) fury all over ( ͡° ͜ʖ ͡°) and ( ͡° ͜ʖ ͡°) will ( ͡° ͜ʖ ͡°) in it. You're ( ͡° ͜ʖ ͡°) dead, ( ͡° ͜ʖ ͡°).",
            @"▄█▀ █▬█ █ ▀█▀",
            @"ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ༼ຈل͜ຈ༽ﾉ☂ ɪᴛs ʀᴀɪɴɪɴɢ sᴀʟᴛ! ヽ༼ຈل͜ຈ༽ﾉ☂ ヽ｀ヽ｀、ヽヽ｀ヽ｀、｀ヽ｀、ヽヽ｀ヽ｀、ヽヽ｀ヽ、ヽヽ｀ヽ",
            @"ˢʷᵉᵃʳ ᵗᵒ ᵍᵒᵈ ᶦᶠ ᵃᶰʸ ᵒᶠ ʸᵒᵘ ᵐᵒᵗʰᵉʳʳᶠᵘᶜᵏᵉʳˢ ᵗʸᵖᵉ LUL ʸᵒᵘ ʷᶦᶫᶫ ᵇᵉ ᶦᶰ ˢᵉʳᶦᵒᵘˢ ᵗʳᵒᵘᵇᶫᵉ",
            @"Life is like a cabbage: Sometimes it is green and crunchy, sometimes dad stabs the cat with a knife because his foot ball team lose again",
            @"Life is like a cabbage: sometimes it is green and round, and sometimes mom wish you were never born",
            @"If there is a fire in your house make sure you save all the cabbages before you even think about finding your children",
            @"Sometimes you hate your life and dont want to be alive anymore but then you think about cabbage and know that everything will be ok",
            @"If you push a cabbage under water he will alway float right back up to the top because he miss you so much",
            @"(   ͡° ͜ʖ ͡° )(   ͡° ͜ʖ ͡° )
 (   ͡° ͜ʖ ͡° )  ͡° ͜ʖ ͡° )
  (   ͡° ͜ʖ ͡° )  ͜ʖ ͡° )
   (   ͡° ͜ʖ ͡° )  ͡° )
    (   ͡° ͜ʖ ͡° )° )
     (   ͡° ͜ʖ ͡° )
    ( (   ͡° ͜ʖ ͡° )
   (   (   ͡° ͜ʖ ͡° )
  (   ͡° (   ͡° ͜ʖ ͡° )
 (   ͡° ͜ʖ (   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° (   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° )(   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° ) (   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° )(   ͡° ͜ʖ ͡° )
 (   ͡° ͜ʖ ͡° )  ͡° ͜ʖ ͡° )
  (   ͡° ͜ʖ ͡° )  ͜ʖ ͡° )
   (   ͡° ͜ʖ ͡° )  ͡° )
    (   ͡° ͜ʖ ͡° )° )
     (   ͡° ͜ʖ ͡° ))
     (   ͡° ͜ʖ ͡° )
    ( (   ͡° ͜ʖ ͡° )
   (   (   ͡° ͜ʖ ͡° )
  (   ͡° (   ͡° ͜ʖ ͡° )
 (   ͡° ͜ʖ (   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° (   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° )(   ͡° ͜ʖ ͡° )
(   ͡° ͜ʖ ͡° ) (   ͡° ͜ʖ ͡° )",
            @":zzz:　:pizza:
   :zzz::pizza:
　 :fries:
　:spaghetti::zzz:
 :pizza:　:zzz:
:meat_on_bone:　　:zzz:
:hamburger:　　:zzz:
 :pizza:　:zzz:
   :fries::zzz:
　  :zzz:
　:zzz: :doughnut:
 :zzz:　 :spaghetti:
:zzz:　　:chocolate_bar:
:zzz:　　 :hamburger:
 :zzz:　  :fried_shrimp:
　:zzz::sushi:
     :poultry_leg:
  :cake:    :zzz:",
            @":joy: :joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :100: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :100: :100: :100: :100: :100: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :100: :100: :100: :joy: :100: :100: :100: :joy: 
:joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :100: :100: :joy: :joy: :joy: :100: :100: :100: 
:100: :100: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :100: :100:
:100: :100: :100: :joy: :joy: :joy: :100: :100: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: 
:joy: :100: :100: :100: :joy: :100: :100: :100: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :100: :100: :100: :100: :100: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :100: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: 
:joy: :joy: :joy: :joy: :joy: :joy: :joy: :joy: :100: :100: :joy: :joy: :joy: :joy: :joy: :joy: :joy:"
        };
    }
}
