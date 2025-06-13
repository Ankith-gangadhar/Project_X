import React, { useRef } from 'react';
import gsap from 'gsap';
import { useGSAP } from '@gsap/react';
import { ScrollTrigger } from 'gsap/ScrollTrigger';
import '../styles/animations.css';

gsap.registerPlugin(useGSAP, ScrollTrigger);

const AnimatedProfit = ({ profit }) => {
  const container = useRef();
  const tl = useRef();

  useGSAP(() => {
    gsap.set('.profit-box, .profit-value', { opacity: 0, y: 20 });
    
    // Create main timeline
    tl.current = gsap.timeline({
      scrollTrigger: {
        trigger: ".profit-container",
        start: "top center",
        end: "bottom center",
        scrub: 1,
        markers: false, // Remove in production
        toggleActions: "play none none reverse"
      }
    })
    .to('.profit-box', { 
      opacity: 1,
      y: 0,
      duration: 0.8,
      ease: 'power2.out'
    })
    .to('.profit-value', {
      opacity: 1,
      y: 0,
      stagger: 0.2,
      duration: 0.6,
      ease: 'back.out(1.7)'
    }, '-=0.3');

    // Scroll navigation setup
    ScrollTrigger.create({
      trigger: ".profit-container",
      start: "top center",
      endTrigger: "body",
      end: "bottom bottom",
      toggleClass: "active-section",
      id: "profit-section",
      onEnter: () => {
        window.history.replaceState(null, null, "#profit");
      },
      onLeaveBack: () => {
        window.history.replaceState(null, null, " ");
      }
    });

  }, { scope: container });

  return (
    <div ref={container} className="profit-container" id="profit">
      <div className="profit-box">
        <h3>Total Profit</h3>
        <div className="profit-value">₹{profit}</div>
      </div>
    </div>
  );
};

export default AnimatedProfit;
