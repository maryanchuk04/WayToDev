import { Component, OnInit } from '@angular/core';
import {Canvas, ClickMode, Container, Engine, HoverMode, Move, MoveDirection} from "tsparticles-engine";
import {OutMode} from "tsparticles-engine";
import { loadFull } from "tsparticles";

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.css']
})
export class PreviewComponent implements OnInit {
  id = "tsparticles";
  particlesUrl = "http://foo.bar/particles.json";
  particlesOptions = {
    particles: {
      number: {
        value: 90,
        density: {
          enable: true,
          value_area: 800
        }
      },
      color: {
        value: "#ffffff"
      },
      shape: {
        type: "circle",
        stroke: {
          width: 0,
          color: "#000000"
        },
        polygon: {
          nb_sides: 3
        },
        image: {
          src: "img/github.svg",
          width: 100,
          height: 100
        }
      },
      opacity: {
        value: 0.5,
        random: false,
        anim: {
          enable: false,
          speed: 1,
          opacity_min: 0.1,
          sync: false
        }
      },
      size: {
        value: 3,
        random: true,
        anim: {
          enable: false,
          speed: 5,
          size_min: 0.1,
          sync: false
        }
      },
      line_linked: {
        enable: true,
        distance: 150,
        color: "#ffffff",
        opacity: 0.4,
        width: 1
      },
      move: {
        enable: true,
        speed: 3,
        direction: MoveDirection.none,
        random: false,
        straight: false,
        outModes: {
          default: OutMode.bounce,
        },
        bounce: false,
        attract: {
          enable: false,
          rotateX: 600,
          rotateY: 1200
        }
      }
    },
    interactivity: {
      events: {
        onhover: {
          enable: true,
          mode: HoverMode.grab
        },
        onclick: {
          enable: false,
          mode: ClickMode.remove
        },
        resize: true
      },
      modes: {
        grab: {
          distance: 347.65234765234766,
          line_linked: {
            opacity: 0.2671394224931395
          }
        },
        bubble: {
          distance: 400,
          size: 40,
          duration: 2,
          opacity: 8,
          speed: 3
        },
        repulse: {
          distance: 495.5044955044955,
          duration: 0.4
        },
        push: {
          particles_nb: 4
        },
        remove: {
          particles_nb: 2
        }
      }
    },
    retina_detect: true
  };

  particlesLoaded(container: Container): void {
    console.log(container);
  }

  async particlesInit(engine: Engine): Promise<void> {
    console.log(engine);

    // Starting from 1.19.0 you can add custom presets or shape here, using the current tsParticles instance (main)
    // this loads the tsparticles package bundle, it's the easiest method for getting everything ready
    // starting from v2 you can add only the features you need reducing the bundle size
    await loadFull(engine);
  }

  constructor() { }

  ngOnInit(): void {
  }

  // ngOnInit(): void {
  //   particlesJS.load("particles-js","../../../assets/particle-config.json",null);
  //
  // }

}
