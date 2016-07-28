using Discord.Modules;

namespace DisLiF.Modules {
    internal partial class DinMammaModule : IModule {
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
            @"ζ༼⊙ ͟ل͜ ⊙༽ᶘ ᴀʀᴇ ᴡᴇ ʜᴜᴍᴀɴ ᴏʀ ᴀʀᴇ ᴡᴇ Cᴀɴᴄᴇʀ? ζ༼⊙ ͟ل͜ ⊙༽ᶘ",
            @"You know what I don't understand? No one ever takes copypastas seriously. I'm being honest here. No one ever stops and really understands the copypastas. They just pass it off as just another shitpost that was made by some edgy shit in his basement, waiting for downvotes and hate comments. These people are wrong. copypastas are made by the greatest minds on the planet. Each one is carefully and delicately crafted to get the least amount of karma on Reddit. I'm led to believe that maybe even Ernest Hemingway made a copypasta. Now, I am not talking about the shitty twitter copypastas that don't take any effort at all, like what you see on say, for example, Berny Snaders' page. They lack a soul. I ony speak of 4Chan copypastas and the like. Copypastas that make fun of the saltiness of OP and call his post cancer. These types of copypastas deserve respect. They aren't trash. They are literature. ",
            @"I sexually Identify as a bot. Ever since I was a boy I dreamed of soaring over the chat dropping shitposts and views on disgusting streamers. People say to me that a person being a bot is Impossible and I'm fucking retarded but I don't care, I'm beautiful. I'm having a plastic surgeon install keyboards, hard drives and mobile access points on my body. From now on I want you guys to call me 'Marvin' and respect my right to shitpost from above and shitpost needlessly. If you can't accept me you're a botophobe and need to check your digital privilege. Thank you for being so understanding.",
            @"I sexually Identify as Soldier 76. Ever since I was a boy I dreamed of sprinting around using aimbot to gun people down, screaming 'TANGO DOWN' into my mic after every collateral. People say to me that being Soldier 76 is Impossible and I’m fucking retarded but I don’t care, I’m beautiful. I’m having a plastic surgeon install an augmented reality visor into my face, and Lockheed Martin design and build me a heavy pulse rifle with triple 70mm helix rocket clusters. From now on I want you guys to call me “John 'Jack' Morrison” and respect my right to kill and kill needlessly. If you can’t accept me you’re a soldierphobe and need to check your soldier privilege. Thank you for being so understanding."
        };
    }
}
