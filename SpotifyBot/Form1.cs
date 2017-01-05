using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;
using SpotifyAPI.Local;

namespace SpotifyBot {
    public partial class Form1 : Form {

        private readonly DiscordSocketClient _client;
        private readonly SpotifyLocalAPI _spotify;

        private BotState _state;

        public Form1() {
            InitializeComponent();

            _client = new DiscordSocketClient();
        
            _spotify = new SpotifyLocalAPI() {
                ListenForEvents = true
            };
            _spotify.Connect();
            _spotify.OnTrackChange += SpotifyOnOnTrackChange;
            _spotify.OnPlayStateChange += SpotifyOnOnPlayStateChange;
            
        }

        private void SpotifyOnOnPlayStateChange(object sender, PlayStateEventArgs e) {
            if (e.Playing) {
                if (_spotify.GetStatus().Track.IsAd()) return;
                Task.Run(async () => {
                    await _client.SetGameAsync($"{_spotify.GetStatus().Track.ArtistResource.Name} - {_spotify.GetStatus().Track.TrackResource.Name}");
                });
                return;
            }

            Task.Run(async () => {
                await _client.SetGameAsync(null);
            });
        }

        private async Task Bot() {
            await _client.LoginAsync(TokenType.User, tbToken.Text);
            await _client.ConnectAsync();
        }

        private void SpotifyOnOnTrackChange(object sender, TrackChangeEventArgs e) {
            try {
                if (_state == BotState.Paused || _state == BotState.Uninitialized) return;
                if (e.NewTrack.IsAd()) return;
                Task.Run(async () => {
                    await _client.SetGameAsync($"{e.NewTrack.ArtistResource.Name} - {e.NewTrack.TrackResource.Name}");
                });
            } catch (Exception ee) { /*lazy*/ }
        }

        private void btnMain_Click(object sender, System.EventArgs e) {
            try {
                switch (_state) {
                    case BotState.Uninitialized:
                        _state = BotState.Running;
                        btnMain.Text = "Pause";
                        Task.Run(Bot);
                        break;
                    case BotState.Running:
                        btnMain.Text = "Resume";
                        _state = BotState.Paused;
                        Task.Run(async () => {
                            await _client.SetGameAsync(null);
                        });
                        break;
                    case BotState.Paused:
                        btnMain.Text = "Pause";
                        _state = BotState.Running;
                        break;
                }
            }catch(Exception ee) { /*lazy*/ }
        }

        private enum BotState {
            Uninitialized,
            Paused,
            Running
        }
    }
}
