
import React, { PropTypes } from 'react';
import Sound from 'react-sound';

class Music extends React.Component {
    constructor(props) {
        super(props);

        this.url = {
            horseSoundOne: "http://s1download-universal-soundbank.com/mp3/sounds/1278.mp3",
            horseSoundTwo: "http://s1download-universal-soundbank.com/wav/20219.wav"
        };
    }

    componentDidMount() {
    }

    render() {
        return (
            <div>
                <Sound
                    url={this.url.horseSoundTwo}
                    playStatus={Sound.status.PLAYING}
                />
            </div>
        );
    }

}
export default Music;