
import React, { PropTypes } from 'react';
import Sound from 'react-sound';

class Music extends React.Component {
    constructor(props) {
        super(props);

        this.state = { play: false };
        this.url = "http://www.superluigibros.com/downloads/sounds/GAMECUBE/SUPERMARIOSUNSHINE/WAV/mario_haha!.wav";
        this.audio = new Audio(this.url);
        this.togglePlay = this.togglePlay.bind(this);


    }

    togglePlay() {
        this.setState({ play: !this.state.play });
        console.log(this.audio);
        this.state.play ? this.audio.play() : this.audio.pause();
    }
PlaySound(){

}
    componentDidMount() {
        let item = document.getElementById("mainText");
        item.addEventListener('mouseover', this.PlaySound, false);
    }

    render() {
        return (
            <div>
                <Sound
                    url={this.url}
                    playStatus={Sound.status.PLAYING}
                />
                {/* <button onClick={this.togglePlay}>{this.state.play ? 'Pause' : 'Play'}</button> */}
            </div>
        );
    }

}
Music.PropTypes = {


};
export default Music;